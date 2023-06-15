import random
import time


def print_playing_field(val):
    print(f"\n\t     |     |\n\t  {val[0]}  |  {val[1]}  |  {val[2]}\n\t_____|_____|_____")   
    print(f"\t     |     |\n\t  {val[3]}  |  {val[4]}  |  {val[5]}\n\t_____|_____|_____") 
    print(f"\t     |     |\n\t  {val[6]}  |  {val[7]}  |  {val[8]}\n") 
    


def take_input(player: str, board: list):
    valid = False
    if player == "Player":         
        while not valid:
            player_answer = input(f"Выбирает {player}... ")
            try:
                player_answer = int(player_answer)
            except:
                print ("Некорректный ввод. Вы уверены, что ввели число?")
                continue
            if player_answer >= 1 and player_answer <= 9:
                if (str(board[player_answer-1]) not in "XO"):
                    if player == "Player":
                        board[player_answer-1] = "O"
                    if player == "Bot":
                        board[player_answer-1] = "X"
                    valid = True
                else:
                    print ("Эта клеточка уже занята")
            else:
                print ("Некорректный ввод. Введите число от 1 до 9 чтобы походить.")
    else:
        print(f"Выбирает {player}..." , end="")
        while not valid:
            my_list = [0, 1, 2, 3, 4, 5, 6, 7, 8]
            result = intelect(board)
            if result != False:
                board[result] = "X"
                valid = True
            else:
                tmp = random.choice(my_list)            
                if str(board[tmp]).isdigit():
                    board[tmp] = "X"
                    valid = True
                    print(tmp + 1)
                else:
                    my_list.pop(tmp)
                    continue


def check_win(board: list) -> bool:
    win_coord = ((0,1,2),(3,4,5),(6,7,8),(0,3,6),(1,4,7),(2,5,8),(0,4,8),(2,4,6))
    for win in win_coord:
        if board[win[0]] == board[win[1]] == board[win[2]]:
            return board[win[0]]
    return False

def main(board: list):
    counter = 0
    win = False
    while not win:
        print_playing_field(board)
        if counter % 2 == 0:
            take_input("Player", board)
        else:
            take_input("Bot", board)
        counter += 1
        if counter > 4:
            tmp = check_win(board)
            if tmp == "O":
                print ("\033[32m Вы выиграли!")
                win = True
                break
            elif tmp == "X":
                print ("\033[31m Выиграл Бот!")
                win = True
                break
        if counter == 9:
            print ("\033[33mНичья!")
            break

    print_playing_field(board)

def intelect(board: list) -> int:
# win check
     if str(board[0]).isdigit() and board[1] == "X" and board[2] == "X": return 0
     elif str(board[1]).isdigit() and board[0] == "X" and board[2] == "X": return 1
     elif str(board[2]).isdigit() and board[0] == "X" and board[1] == "X": return 2

     elif str(board[3]).isdigit() and board[4] == "X" and board[5] == "X": return 3
     elif str(board[4]).isdigit() and board[3] == "X" and board[5] == "X": return 4
     elif str(board[5]).isdigit() and board[3] == "X" and board[4] == "X": return 5

     elif str(board[6]).isdigit() and board[7] == "X" and board[8] == "X": return 6
     elif str(board[7]).isdigit() and board[6] == "X" and board[8] == "X": return 7
     elif str(board[8]).isdigit() and board[6] == "X" and board[7] == "X": return 8

     elif str(board[0]).isdigit() and board[3] == "X" and board[6] == "X": return 0
     elif str(board[3]).isdigit() and board[0] == "X" and board[6] == "X": return 3
     elif str(board[6]).isdigit() and board[0] == "X" and board[3] == "X": return 6

     elif str(board[1]).isdigit() and board[4] == "X" and board[7] == "X": return 1
     elif str(board[4]).isdigit() and board[1] == "X" and board[7] == "X": return 4
     elif str(board[7]).isdigit() and board[1] == "X" and board[4] == "X": return 7

     elif str(board[2]).isdigit() and board[5] == "X" and board[8] == "X": return 2
     elif str(board[5]).isdigit() and board[2] == "X" and board[8] == "X": return 5
     elif str(board[8]).isdigit() and board[2] == "X" and board[5] == "X": return 8

     elif str(board[0]).isdigit() and board[4] == "X" and board[8] == "X": return 0
     elif str(board[4]).isdigit() and board[0] == "X" and board[8] == "X": return 4
     elif str(board[8]).isdigit() and board[0] == "X" and board[4] == "X": return 8

     elif str(board[2]).isdigit() and board[4] == "X" and board[6] == "X": return 2
     elif str(board[4]).isdigit() and board[2] == "X" and board[6] == "X": return 4
     elif str(board[6]).isdigit() and board[2] == "X" and board[4] == "X": return 6

# apponent check

     elif str(board[0]).isdigit() and board[1] == "O" and board[2] == "O": return 0
     elif str(board[1]).isdigit() and board[0] == "O" and board[2] == "O": return 1
     elif str(board[2]).isdigit() and board[0] == "O" and board[1] == "O": return 2

     elif str(board[3]).isdigit() and board[4] == "O" and board[5] == "O": return 3
     elif str(board[4]).isdigit() and board[3] == "O" and board[5] == "O": return 4
     elif str(board[5]).isdigit() and board[3] == "O" and board[4] == "O": return 5

     elif str(board[6]).isdigit() and board[7] == "O" and board[8] == "O": return 6
     elif str(board[7]).isdigit() and board[6] == "O" and board[8] == "O": return 7
     elif str(board[8]).isdigit() and board[6] == "O" and board[7] == "O": return 8

     elif str(board[0]).isdigit() and board[3] == "O" and board[6] == "O": return 0
     elif str(board[3]).isdigit() and board[0] == "O" and board[6] == "O": return 3
     elif str(board[6]).isdigit() and board[0] == "O" and board[3] == "O": return 6

     elif str(board[1]).isdigit() and board[4] == "O" and board[7] == "O": return 1
     elif str(board[4]).isdigit() and board[1] == "O" and board[7] == "O": return 4
     elif str(board[7]).isdigit() and board[1] == "O" and board[4] == "O": return 7

     elif str(board[2]).isdigit() and board[5] == "O" and board[8] == "O": return 2
     elif str(board[5]).isdigit() and board[2] == "O" and board[8] == "O": return 5
     elif str(board[8]).isdigit() and board[2] == "O" and board[5] == "O": return 8

     elif str(board[0]).isdigit() and board[4] == "O" and board[8] == "O": return 0
     elif str(board[4]).isdigit() and board[0] == "O" and board[8] == "O": return 4
     elif str(board[8]).isdigit() and board[0] == "O" and board[4] == "O": return 8

     elif str(board[2]).isdigit() and board[4] == "O" and board[6] == "O": return 2
     elif str(board[4]).isdigit() and board[2] == "O" and board[6] == "O": return 4
     elif str(board[6]).isdigit() and board[2] == "O" and board[4] == "O": return 6

     else: return False
     




        