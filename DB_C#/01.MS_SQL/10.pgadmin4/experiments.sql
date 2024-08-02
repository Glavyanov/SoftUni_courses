--SELECT * FROM payment
--WHERE
--(customer_id = 322 OR customer_id = 346 OR customer_id = 354)
--AND amount < 2 OR amount > 10
--ORDER BY customer_id ASC

--01.08.2024

--SELECT * 
--FROM actor 
--WHERE first_name LIKE 'A%'
--
--SELECT *
--FROM actor
--WHERE first_name ILIKE 'a%'
--

--SELECT customer_id
--	, SUM(amount) AS PaymentsSum
--	, MAX(amount) AS Maximum
--	, MIN(amount) AS Minimum
--FROM payment
--WHERE customer_id > 4
--GROUP BY customer_id
--ORDER BY PaymentsSum DESC


--group by multiple columns
SELECT staff_id
	 , DATE(payment_date)
	 , SUM(amount)
	 , COUNT(*)
FROM payment
WHERE amount != 0
GROUP BY staff_id, DATE(payment_date)
HAVING COUNT(*) > 330
ORDER BY COUNT(*) DESC


--functions
  --strings
SELECT 
	LOWER(email) AS email_upper
  , email
  , LENGTH(email) AS length_of_email
FROM customer
WHERE LENGTH(email) > 37
ORDER BY length_of_email DESC

--concatenate

SELECT 
LEFT(first_name, 1 ) || '.' || LEFT(last_name, 1 )  || '.'
FROM customer


SELECT 
	  POSITION('@' IN email)
	, email
FROM customer


SELECT 
	  LEFT(email, POSITION('@' IN email) - 1)
	, email
FROM customer

--substring
SELECT 
	SUBSTRING(email from 0 for 5) AS extract
  , email
  , SUBSTRING(email from POSITION('.' in email) + 1 for LENGTH(email)) AS after_dot
FROM customer


--extracts
SELECT
	*
	, EXTRACT(dow from rental_date ) AS day_of_week
	, EXTRACT(day from rental_date ) AS day_of_month
	, EXTRACT(doy from rental_date ) AS day_of_year
FROM rental
ORDER BY day_of_year DESC


--to_chars
SELECT
	*
	, EXTRACT(month from payment_date) 
	, TO_CHAR(payment_date, 'Dy, Month YYYY')
FROM payment

--timestamps
SELECT CURRENT_DATE
SELECT CURRENT_TIMESTAMP

SELECT
	 CURRENT_TIMESTAMP
	,CURRENT_TIMESTAMP-rental_date
FROM rental

--CASE WHEN
SELECT * FROM payment
SELECT 
	 amount
   , CASE
   		WHEN amount < 2 THEN 'low amount'
   		WHEN amount < 5 THEN 'medium amount'
		ELSE 'high amount'
	 END
FROM payment


SELECT 
	 rating
   , CASE 
   		WHEN rating IN('PG', 'G') THEN 1 
		ELSE 0
	 END
   , (SELECT SUM(CASE 
   				WHEN rating IN('PG', 'G') THEN 1 
				ELSE 0
	 		  END)
	   FROM film) AS no_of_ratings_with_g_or_pg
FROM film

SELECT *  FROM (SELECT first_name, last_name FROM actor
					UNION
				SELECT first_name, last_name FROM staff
			    ) ORDER BY first_name

--correlated subqueries in WHERE
SELECT name, sales, city FROM employee e1
WHERE sales > ( SELECT AVG(sales) 
				FROM employee e2 
				WHERE e1.city = e2.city
			  )
ORDER BY city ASC

--CREATE VIEW customer_spending
--AS
--SELECT  
--	  first_name || ' ' || last_name AS name
--	, SUM(amount) AS total_amount
--FROM customer AS c
--LEFT JOIN payment AS p ON c.customer_id = p.customer_id
--GROUP BY first_name || ' ' || last_name


--same
SELECT * 
      , (SELECT SUM(price) FROM sales AS s1 WHERE s1.customer_id = s2.customer_id) AS total_spent_by_customer
FROM sales AS s2
--Window Functions(OVER PARTITION BY)
--same but more fast with partition by
SELECT * 
      , SUM(price) OVER(PARTITION BY customer_id) AS total_spent_by_customer
FROM sales
ORDER BY transaction_id ASC

SELECT SUM(price) AS sum_price FROM sales WHERE customer_id = 1


SELECT * 
      , COUNT(*) OVER(PARTITION BY payment_type) AS no_of_transactions
FROM sales
ORDER BY no_of_transactions DESC 

SELECT * FROM sales WHERE transaction_id = 4408

SELECT *
	 , SUM(amount) OVER (PARTITION BY customer_id)
	 , COUNT(*) OVER (PARTITION BY customer_id)
	 , COUNT(*) OVER () AS total_count_of_transactions
FROM payment

--OVER ORDER BY

SELECT * 
	 , SUM(amount) OVER(ORDER BY payment_date) AS sum_with_aggregation_from_previous_row
FROM payment

SELECT * 
	 , SUM(amount) OVER(PARTITION BY customer_id ORDER BY payment_id) AS sum_with_aggregation_from_previous_row
FROM payment

--RANKING
SELECT * FROM (SELECT 
					 f.title
				   , c.name
				   , f.length
				   , DENSE_RANK() OVER (PARTITION BY c.name ORDER BY f.length DESC) AS rank_example
				FROM film AS f
				LEFT JOIN film_category AS fc ON fc.film_id = f.film_id
				LEFT JOIN category AS c ON c.category_id = fc.category_id ) AS exmpl
WHERE exmpl.rank_example IN (1, 2)

--LEAD & LAG (interesting)
SELECT 
      cs.name
    , cs.country
    , COUNT(*)
    , LEAD(cs.name) OVER (PARTITION BY cs.country ORDER BY COUNT(*) ASC) AS rank_exmpl
 FROM customer_list AS cs
 LEFT JOIN payment AS p ON p.customer_id = cs.id
GROUP BY cs.name, cs.country

SELECT 
      cs.name
    , cs.country
    , COUNT(*)
    , LEAD(COUNT(*)) OVER (PARTITION BY cs.country ORDER BY COUNT(*) ASC) AS rank_exmpl
 FROM customer_list AS cs
 LEFT JOIN payment AS p ON p.customer_id = cs.id
GROUP BY cs.name, cs.country

SELECT 
      cs.name
    , cs.country
    , COUNT(*)
    , LEAD(COUNT(*)) OVER (PARTITION BY cs.country ORDER BY COUNT(*) ASC) AS rank_exmpl
    , LEAD(COUNT(*)) OVER (PARTITION BY cs.country ORDER BY COUNT(*) ASC) - COUNT(*) AS diff_between_next
 FROM customer_list AS cs
 LEFT JOIN payment AS p ON p.customer_id = cs.id
GROUP BY cs.name, cs.country

SELECT 
      cs.name
    , cs.country
    , COUNT(*)
    , LAG(COUNT(*)) OVER (PARTITION BY cs.country ORDER BY COUNT(*) ASC) AS rank_exmpl
    , LAG(COUNT(*)) OVER (PARTITION BY cs.country ORDER BY COUNT(*) ASC) - COUNT(*) AS diff_between_prev
 FROM customer_list AS cs
 LEFT JOIN payment AS p ON p.customer_id = cs.id
GROUP BY cs.name, cs.country

--GROUPING SETS

SELECT 
	  TO_CHAR(payment_date, 'Month') AS month
    , staff_id
    , SUM(amount)
 FROM payment
GROUP BY 
      GROUPING SETS( 
		    (staff_id)
		  , (month)
		  , (staff_id, month))

--ROLLUP (also hierarchy of grouping sets)
SELECT * FROM payment

SELECT 
	  'Q' || TO_CHAR(payment_date, 'Q') AS quarter --just use Q to get a quarter of year
	, EXTRACT(month from payment_date) AS month
	, CASE WHEN DATE(payment_date) IS NOT NULL THEN CAST(DATE(payment_date) AS text) ELSE 'Total' END AS date
	, SUM(amount)
 FROM payment
GROUP BY ROLLUP(
			  'Q' || TO_CHAR(payment_date, 'Q')
			, EXTRACT(month from payment_date)
			, DATE(payment_date))
ORDER BY quarter, month, date







