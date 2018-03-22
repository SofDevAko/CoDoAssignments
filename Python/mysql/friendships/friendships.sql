SELECT users.first_name, users.last_name, users.first_name AS users2_first_name, users.last_name AS users2_last_name FROM users
LEFT JOIN friendships ON friendships.users_id = users.id
LEFT JOIN users AS users2 ON users2.id = friendships.users_id1