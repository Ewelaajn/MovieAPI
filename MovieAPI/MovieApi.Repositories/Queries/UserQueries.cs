using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MovieApi.Repositories.Queries
{
    public static class UserQueries
    {
        public const string CreateUser = @"
                            INSERT INTO film.user (nickname, first_name, last_name, mail, password)
                            VALUES (@NickName, @FirstName, @LastName, @Mail, @Password)
                            RETURNING id AS Id, nickname AS NickName, first_name AS FirstName, 
                                      last_name AS LastName, mail AS Mail, password AS Password";

        public const string GetPasswordByMail = @" 
                            SELECT password FROM film.user WHERE mail = @mail";
    }
}
