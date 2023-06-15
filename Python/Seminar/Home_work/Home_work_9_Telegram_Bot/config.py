from aiogram import Bot, Dispatcher
import os

bot = Bot(token=os.getenv("Token"))
dp = Dispatcher(bot)
