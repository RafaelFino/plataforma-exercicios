#!/bin/bash

BASE="http://localhost:5218/api/client"
FAILURES=0
IDS=()

echo "====================================="
echo "## API Integration Test Started"
echo "====================================="

########################################
echo ""
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

  echo "$RESPONSE" | jq .

  SUCCESS=$(echo "$RESPONSE" | jq -r '.success')
  ID=$(echo "$RESPONSE" | jq -r '.data.id')

  if [ "$SUCCESS" = "true" ] && [ "$ID" != "null" ]; then
    IDS+=("$ID")
  else
    ((FAILURES++))
  fi
done

########################################
echo ""
echo ">> Get All..."

RESPONSE=$(curl -s $BASE)
echo "$RESPONSE" | jq .

SUCCESS=$(echo "$RESPONSE" | jq -r '.success')
if [ "$SUCCESS" != "true" ]; then
  ((FAILURES++))
fi

########################################
echo ""
echo ">> Get By ID..."

for ID in "${IDS[@]}"
do
  RESPONSE=$(curl -s $BASE/$ID)
  echo "$RESPONSE" | jq .

  SUCCESS=$(echo "$RESPONSE" | jq -r '.success')

  if [ "$SUCCESS" != "true" ]; then
    ((FAILURES++))
  fi
done

########################################
echo ""
echo ">> Updating..."

for ID in "${IDS[@]}"
do
  RESPONSE=$(curl -s -X PUT $BASE/$ID \
    -H "Content-Type: application/json" \
    -d "{
      \"name\": \"Updated_$RANDOM\",
      \"email\": \"updated_$RANDOM@test.com\",
      \"birthDate\": \"1991-02-02\"
    }")

  echo "$RESPONSE" | jq .

  SUCCESS=$(echo "$RESPONSE" | jq -r '.success')

  if [ "$SUCCESS" != "true" ]; then
    ((FAILURES++))
  fi
done

########################################
echo ""
echo ">> Deleting..."

for ID in "${IDS[@]}"
do
  RESPONSE=$(curl -s -X DELETE $BASE/$ID)

  echo "$RESPONSE" | jq .

  SUCCESS=$(echo "$RESPONSE" | jq -r '.success')

  if [ "$SUCCESS" != "true" ]; then
    ((FAILURES++))
  fi
done

########################################
echo ""
echo ">> Validate deletion (expect success=false)..."

for ID in "${IDS[@]}"
do
  RESPONSE=$(curl -s $BASE/$ID)
  echo "$RESPONSE" | jq .

  SUCCESS=$(echo "$RESPONSE" | jq -r '.success')

  if [ "$SUCCESS" != "false" ]; then
    ((FAILURES++))
  fi
done

########################################
echo ""
echo "====================================="
echo "## Test Finished"
echo "Failures: $FAILURES"

if [ $FAILURES -eq 0 ]; then
  echo "✅ ALL TESTS PASSED"
else
  echo "❌ SOME TESTS FAILED"
fi

echo "====================================="