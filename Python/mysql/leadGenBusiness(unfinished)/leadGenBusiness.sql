1)
SELECT SUM(amount) FROM billing
WHERE charged_datetime LIKE '2012-03-%'

2)
SELECT SUM(amount) FROM billing
WHERE client_id = 2

3)
SELECT SUM(amount) FROM billing
WHERE client_id = 2

4)
SELECT COUNT(domain_name), MONTH(created_datetime), YEAR(created_datetime) FROM sites
WHERE sites.client_id = 20
GROUP BY MONTH(created_datetime), YEAR(created_datetime);

5)
SELECT sites.domain_name, COUNT(leads_id), sites.site_id FROM sites
JOIN leads ON leads.site_id = sites.site_id
WHERE leads.registered_datetime BETWEEN '2011-1-1' AND '2011-2-15'
GROUP BY sites.site_id

6)
