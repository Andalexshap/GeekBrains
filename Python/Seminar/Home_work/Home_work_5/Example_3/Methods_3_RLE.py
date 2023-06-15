def read_file(path: str, atr: str, text = '') -> str:
    with open(path, atr, encoding='utf-8') as data:
        if atr == "r":
            text = data.readline()
        elif atr == "w":
            text = data.writelines(text)
        return text

def rle_encode(data: str) -> str: 
    prev_char = ''
    encode_text = ''
    count = 1
    for let in data:
        if let != prev_char:
            if prev_char: 
                encode_text += str(count) + prev_char 
            count = 1 
            prev_char = let
        else:
            count += 1
    else:
        encode_text += str(count) + prev_char
        return encode_text

def rle_decode(data: str) -> str: 
    decode_text = '' 
    count = 0 
    for char in data: 
        if char.isdigit(): 
            count = count * 10 + int(char)
        else: 
            decode_text += char * count
            count = 0 
    return decode_text