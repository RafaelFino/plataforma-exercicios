#!/bin/bash

BASE="http://localhost:5218/api/client"

echo "## Start..."

IDS=()

echo ">> Creating 10 users..."

for i in {1..10}
do
  NAME="User_$RANDOM"
  EMAIL="user_$RANDOM@test.com"
  BIRTHDATE="1990-01-0$(( (RANDOM % 9) + 1 ))"

  RESPONSE=$(curl -s -X POST $BASE \
    -F "name=$NAME" \
    -F "email=$EMAIL" \
    -F "birthDate=$BIRTHDATE")

  echo "<< Created ID: $RESPONSE"
  IDS+=($RESPONSE)
done

echo ""
echo ">> Get All (formatted)..."
curl -s $BASE | jq .
echo ""

echo ""
echo ">> Get By ID (after create)..."
for ID in "${IDS[@]}"
do
  echo "<< Getting: $ID"
  curl -s $BASE/$ID | jq .
  echo ""
done

echo ""
echo ">> Updating..."

for ID in "${IDS[@]}"
do
  curl -s -X PUT $BASE/$ID \
    -H "Content-Type: application/json" \
    -d "{
      \"id\": \"$ID\",
      \"name\": \"Updated_$RANDOM\",
      \"email\": \"updated_$RANDOM@test.com\",
      \"birthDate\": \"1991-02-02T00:00:00\"
    }" | jq .

  echo "<< Updated: $ID"
done

echo ""
echo ">> Get By ID (after update)..."
for ID in "${IDS[@]}"
do
  echo "<< Checking update: $ID"
  curl -s $BASE/$ID | jq .
  echo ""
done

echo ""
echo ">> Delete..."

for ID in "${IDS[@]}"
do
  curl -s -X DELETE $BASE/$ID
  echo "<< Removed: $ID"
done

echo ""
echo ">> Get By ID (after delete - expect 404)..."
for ID in "${IDS[@]}"
do
  echo -n "<< Checking removal $ID -> HTTP: "
  curl -s -o /dev/null -w "%{http_code}\n" $BASE/$ID
done

echo ""
echo "## Finish."