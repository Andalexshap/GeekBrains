'''Создайте программу для игры с конфетами человек против человека.
Условие задачи: На столе лежит заданное количество конфет. Играют два игрока делая ход друг после друга. 
Первый ход определяется жеребьёвкой. За один ход можно забрать не более чем 28 конфет. 
Все конфеты оппонента достаются сделавшему последний ход.
a) Добавьте игру против бота
b) Подумайте как наделить бота 'интеллектом'
'''
import Methods_ex_1

total_candies = Methods_ex_1.InputNumber("Введите количество конфет")
toss = Methods_ex_1.draw()
while total_candies > 0:
    if toss: 
        print(f"Ваш ход!")
        total_candies -=  Methods_ex_1.player_turn(total_candies)
        if Methods_ex_1.check_win("Player", total_candies):
            break
        toss = False
    if not toss:
        print(f"Ход бота!")
        total_candies -= Methods_ex_1.bot_turn(total_candies)
        if Methods_ex_1.check_win("Bot", total_candies):
            break
        toss = True

print("Игра завершена!!!")