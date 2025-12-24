#!/usr/bin/env python3

def to_bin(text, encoding):
    data = text.encode(encoding)
    return " ".join(f"{byte:08b}" for byte in data)


def to_text(binary, encoding):
    data = bytes(int(b, 2) for b in binary.split())
    return data.decode(encoding)


def main():
    print("\nAction:")
    print("1 - Encode (text -> binary)")
    print("2 - Decode (binary -> text)")

    action = input("Option [1/2]: ").strip()

    try:
        if action == "1":
            text = input("\nEnter the text to encode:\n> ")
            result = to_bin(text, "ascii")
            print("\nBinary output:\n")
            print(result)

        elif action == "2":
            binary = input("\nEnter the binary to decode (space separated):\n> ")
            result = to_text(binary, "ascii")
            print("\nDecoded text:\n")
            print(result)

        else:
            print("Invalid option.")

    except Exception as error:
        print("\nError:")
        print(error)


if __name__ == "__main__":
    main()
