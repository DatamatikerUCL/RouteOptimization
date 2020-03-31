﻿using RelateIT.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace RelateIT.Data
{
    public class TokenDataBaseController
    {
        static object locker = new object();
        SQLiteConnection database;
        public TokenDataBaseController()
        {
            database = SQLiteDatebase.GetConnection();
            database.CreateTable<Token>();
        }

        public Token GetToken()
        {
            lock (locker)
            {
                if (database.Table<Token>().Count() == 0)
                {
                    return null;
                }
                else
                {
                    return database.Table<Token>().First();
                }
            }
        }

        public int SaveToken(Token token)
        {
            lock (locker)
            {
                if (token.ID != 0)
                {
                    database.Update(token);
                    return token.ID;
                }
                else
                {
                    return database.Insert(token);
                }
            }
        }

        public int DeleteToken(int id)
        {
            lock (locker)
            {
                return database.Delete<Token>(id);
            }
        }
    }
}
