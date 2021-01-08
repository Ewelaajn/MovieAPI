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

        public const string IsMailTaken = @"
                            SELECT TRUE FROM film.user WHERE mail = @mail";

        public const string GetUserByMail = @"
                            SELECT id AS Id,
                                   nickname AS Nickname,
                                   first_name AS FirstName,
                                   last_name AS LastName,
                                   mail AS Mail
                            FROM film.user
                            WHERE mail = @mail";
    }
}