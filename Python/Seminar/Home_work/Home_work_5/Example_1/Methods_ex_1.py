import random


def draw() -> bool:
    return random.choice([True, False])


def InputNumber(message: str) -> int:
    while True:
        try:
            number = int(input(f"{message}: "))
            break
        except ValueError:
            print("Это не число!")
    return number

def player_turn(total_candies: int) -> int:
    take = InputNumber("Сколько конфет возьмешь?")
    if 0 < take < 29 and take <= total_candies:
        total_candies -= take
        print(f"Вы взяли {take} конфет и их осталось {total_candies}")
        return take
    elif take > total_candies:
        print("Нельзя взять больше конфет, чем их осталось:")
        return player_turn(total_candies)     
    else:
        if take < 1:
            print("Что то маловато, нужно взять от 1-й до 28-ми конфет!")
            return player_turn(total_candies)
        elif take > 28:
            print("Что то многовато, нужно взять от 1-й до 28-ми конфет!")
            return player_turn(total_candies)

def bot_turn(total_candies: int) -> int:
    if total_candies < 29:
        take = total_candies
        print(f"Бот взял {take} конфет и одержал победу!")
        return take
    elif 28< total_candies < 56:
        take = total_candies - 29
        total_candies -= take
        print(f"Бот взял {take} конфет и их осталось {total_candies}!")
        return take
    else:
        take = random.randint(1,29)
        total_candies -= take
        print(f"Бот взял {take} конфет и их осталось {total_candies}!")
        return take

def check_win(name: str, total_candies: int) -> bool:
    if total_candies == 0: 
        print(f"Победил {name}!")
        return True
