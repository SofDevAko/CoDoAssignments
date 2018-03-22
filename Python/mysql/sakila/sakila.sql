1)
SELECT first_name, last_name, email, CONCAT(address.address,' ', address.address2,' ', address.district,' ', address.postal_code,' ', address.city_id) AS Address from customer
JOIN address ON address.address_id = customer.address_id
WHERE address.city_id = 312

2)
SELECT title, description, release_year, rating, special_features, category.name FROM film
JOIN film_category ON film.film_id = film_category.film_id
JOIN category ON film_category.category_id = category.category_id
WHERE category.name = 'Comedy'

3)
SELECT actor.actor_id, actor.first_name, actor.last_name, film.title, film.description, film.release_year FROM film
JOIN film_actor ON film.film_id = film_actor.film_id
JOIN actor ON film_actor.actor_id = actor.actor_id
WHERE actor.actor_id = 5

4)
SELECT first_name, last_name, email, CONCAT(address.address,' ', address.address2,' ', address.district,' ', address.postal_code) AS Address from customer
JOIN address ON address.address_id = customer.address_id
JOIN store ON store.store_id = customer.store_id
WHERE customer.store_id = 1 AND address.city_id IN (1,42,312,459)

5)
SELECT film.title, film.description, film.release_year, film.rating, film.special_features FROM film
JOIN film_actor ON film.film_id = film_actor.film_id
WHERE film_actor.actor_id = 15 AND film.rating = 'G' AND film.special_features LIKE '%beh%' 

6)
SELECT film.film_id, film.title, actor.actor_id, CONCAT(actor.first_name,' ', actor.last_name) AS actor_name FROM film
JOIN film_actor ON film.film_id = film_actor.film_id
JOIN actor ON film_actor.actor_id = actor.actor_id
WHERE film.film_id = 369

7)
SELECT film.title, description, release_year, rating, special_features, category.name FROM film
JOIN film_category ON film.film_id = film_category.film_id
JOIN category ON film_category.category_id = category.category_id
WHERE category.name = 'Drama' AND film.rental_rate = 2.99

8)
SELECT film.title, description, release_year, rating, special_features, category.name, actor.first_name, actor.last_name FROM film
JOIN film_category ON film.film_id = film_category.film_id
JOIN category ON film_category.category_id = category.category_id
JOIN film_actor ON film.film_id = film_actor.film_id
JOIN actor ON film_actor.actor_id = actor.actor_id
WHERE category.name = 'Action' AND actor.first_name = 'SANDRA' AND actor.last_name = 'KILMER'