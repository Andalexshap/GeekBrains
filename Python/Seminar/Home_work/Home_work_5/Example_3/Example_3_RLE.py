'''
Реализуйте RLE алгоритм: реализуйте модуль сжатия и восстановления данных.
Входные и выходные данные хранятся в отдельных текстовых файлах.
aaaaabbbcccc -> 5a3b4c
5a3b4c -> aaaaabbbcccc
'''
import Methods_3_RLE

input_data = R'Seminar\Home_work\Home_work_5\Example_3\InputData.txt'
result = Methods_3_RLE.read_file(input_data, 'r')
print(f"\n\033[32mИсходные данные:\n{result}")

encode_data = Methods_3_RLE.rle_encode(result)
print(f"\n\033[31mЗакодированные данные:\n{encode_data}")
output_data = R'Seminar\Home_work\Home_work_5\Example_3\EncodeData.txt'
Methods_3_RLE.read_file(output_data, 'w', encode_data)

decode_data = Methods_3_RLE.rle_decode(encode_data)
print(f"\n\033[32mЗакодированные данные:\n{decode_data}")
print("\033[37m")
output_data = R'Seminar\Home_work\Home_work_5\Example_3\DecodeData.txt'
Methods_3_RLE.read_file(output_data, 'w', decode_data)
