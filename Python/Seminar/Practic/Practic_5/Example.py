my_str = 'АБВ ылоажы фыыдлх абв Зщышф вабвв ффлжв абВ'

my_str = my_str.lower().replace('абв', '').replace('  ', '').strip()
print(my_str)