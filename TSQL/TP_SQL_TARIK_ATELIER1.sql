-- Atelier 1

-- 1. 

-- Liste des ateliers dont le genre est 'SCIENCES'

SELECT A.INTITULE, A.GENRE, AN.NOM, AN.PRENOM FROM atelier A
JOIN animateur AN ON A.NO_ANIM = AN.NO_ANIM
WHERE A.GENRE = 'SCIENCES';

-- Liste des inscriptions pour les adhérents de la ville de Nantes

SELECT A.INTITULE, I.JOUR, AD.NOM, AD.PRENOM, I.DATE_INSCRIPTION FROM atelier A
JOIN inscription I ON A.NO_ATEL = I.NO_ATEL
JOIN  adherent AD ON I.NO_ADHER = AD.NO_ADHER
WHERE AD.VILLE = 'Nantes' ;

-- Moyenne des notes par atelier :

SELECT A.INTITULE, AVG(I.NOTE) NOTE_MOYENNE FROM atelier A
JOIN inscription I ON A.NO_ATEL = I.NO_ATEL
GROUP BY A.INTITULE;

-- Nombre des inscriptions par ville et par atelier

SELECT AD.VILLE, A.GENRE, COUNT(NO_INSC) AS INSCRITS FROM atelier A
JOIN inscription I ON A.NO_ATEL = I.NO_ATEL
JOIN  adherent AD ON I.NO_ADHER = AD.NO_ADHER
GROUP BY AD.VILLE, A.GENRE;

-- La liste des animateurs qui n’ont pas d’atelier

SELECT AN.NOM, AN.PRENOM, AN.TEL FROM atelier A
RIGHT JOIN animateur AN ON A.NO_ANIM = AN.NO_ANIM
WHERE A.NO_ANIM IS NULL;

-- La liste des adhérents inscrits à la fois dans un atelier de SCIENCES et un atelier de TNIC

SELECT AD.NOM, AD.PRENOM, AD.VILLE FROM adherent AD
JOIN inscription I ON I.NO_ADHER = AD.NO_ADHER
JOIN activite AC ON I.JOUR = AC.JOUR
JOIN atelier A ON A.NO_ATEL = AC.NO_ATEL
WHERE A.GENRE = 'SCIENCES'
INTERSECT
SELECT AD.NOM, AD.PRENOM, AD.VILLE FROM adherent AD
JOIN inscription I ON I.NO_ADHER = AD.NO_ADHER
JOIN activite AC ON I.JOUR = AC.JOUR
JOIN atelier A ON A.NO_ATEL = AC.NO_ATEL
WHERE A.GENRE = 'TNIC'

-- La liste des adhérents qui sont dans l’atelier Poterie ou l’atelier peinture ou les deux

SELECT AD.NOM, AD.PRENOM, A.INTITULE FROM adherent AD 
JOIN inscription I ON I.NO_ADHER = AD.NO_ADHER
JOIN atelier A ON A.NO_ATEL = I.NO_ATEL
WHERE A.INTITULE IN ('POTERIE','PEINTURE');

-- La liste des ateliers qui ont plus de 2 inscrits

SELECT A.NO_ATEL, A.INTITULE, A.GENRE FROM atelier A 
JOIN inscription I ON A.NO_ATEL=I.NO_ATEL
GROUP BY A.NO_ATEL, A.INTITULE, A.GENRE
HAVING COUNT(*)>2;

--La liste des ateliers dont l’age moyen des inscrits est supérieur à 32 ans

SELECT A.NO_ATEL, A.INTITULE, AVG(DATEDIFF(YEAR, AD.DATE_NAISSANCE , GETDATE())) AS AGE_MOYEN FROM atelier A 
JOIN inscription I ON A.NO_ATEL = I.NO_ATEL
JOIN  adherent AD ON I.NO_ADHER = AD.NO_ADHER
GROUP BY A.NO_ATEL, A.INTITULE
HAVING AVG(DATEDIFF(YEAR, AD.DATE_NAISSANCE , GETDATE())) > 32;



-----

-- Atelier 2

-- Liste de l’adhérent le plus jeune inscrit dans le genre « SPORT »

SELECT AD.NO_ADHER, AD.NOM, AD.PRENOM, AD.DATE_NAISSANCE FROM adherent AD 
WHERE DATE_NAISSANCE = ( SELECT MAX(AD.DATE_NAISSANCE) FROM adherent AD 
						JOIN inscription I ON I.NO_ADHER= AD.NO_ADHER
						JOIN atelier A ON A.NO_ATEL=I.NO_ATEL
						WHERE A.GENRE='SPORT');


-- Liste des personnes habitant dans la même ville que M. Germain

SELECT NOM, PRENOM, VILLE FROM adherent
WHERE NOM!='GERMAIN' AND VILLE = (SELECT VILLE FROM adherent
				WHERE NOM = 'GERMAIN' AND SEXE = 'M');


-- Liste des adhérents qui ont le même animateur : M. POIRIER

SELECT AD.NO_ADHER, AD.NOM, AD.PRENOM FROM adherent AD
JOIN inscription I ON I.NO_ADHER = AD.NO_ADHER
JOIN atelier A ON A.NO_ATEL = I.NO_ATEL
JOIN animateur AN ON AN.NO_ANIM = A.NO_ANIM
WHERE AN.NOM = 'POIRIER'

-- Liste des adhérents les plus âgés de chaque ville

SELECT  AD.NOM, AD.PRENOM, AD.VILLE, AD.DATE_NAISSANCE FROM adherent AD
LEFT JOIN adherent AD2 ON AD.VILLE = AD2.VILLE AND AD.DATE_NAISSANCE > AD2.DATE_NAISSANCE
WHERE AD2.DATE_NAISSANCE IS NULL;

SELECT  AD.NOM, AD.PRENOM, AD.VILLE, AD.DATE_NAISSANCE FROM adherent AD
WHERE DATE_NAISSANCE IN 
(SELECT MIN(DATE_NAISSANCE) FROM adherent
GROUP BY VILLE)

-- Liste de la meilleure note pour chaque atelier

SELECT AD.NO_ADHER, AD.NOM, AD.PRENOM, I1.NOTE, A.INTITULE FROM atelier A
JOIN inscription I1 ON A.NO_ATEL = I1.NO_ATEL
JOIN  adherent AD ON I1.NO_ADHER = AD.NO_ADHER
WHERE NOTE=(SELECT MAX(NOTE) MEILLEUR_NOTE 
FROM inscription I2 WHERE I1.NO_ATEL = I2.NO_ATEL)
ORDER BY INTITULE


-- Pourcentage des adhérents de chaque ville

SELECT VILLE, CONCAT(CAST(ROUND(COUNT(*)*100.0/(SELECT COUNT(NO_ADHER) FROM adherent),2) AS DECIMAL (5,2)),'%') FROM adherent 
GROUP BY VILLE;

-- Facture pour l’adhérent n°6
SELECT SUM(AC.DUREE*A.VENTE_HEURE) AS TOTAL FROM inscription I 
JOIN activite AC ON AC.JOUR = I.JOUR AND AC.NO_ATEL = I.NO_ATEL
JOIN atelier A ON A.NO_ATEL = AC.NO_ATEL
WHERE I.NO_ADHER = 6;

SELECT AD.NO_ADHER, AD.NOM, AD.PRENOM, AD.RUE, AD.CP, AD.VILLE, A.INTITULE, AC.JOUR, AC.DUREE, A.VENTE_HEURE,
(AC.DUREE*A.VENTE_HEURE) AS MONTANT , TOTAL
FROM adherent AD
JOIN inscription I ON I.NO_ADHER = AD.NO_ADHER
JOIN activite AC ON AC.JOUR = I.JOUR AND I.NO_ATEL=AC.NO_ATEL
JOIN atelier A ON A.NO_ATEL = AC.NO_ATEL
JOIN animateur AN ON AN.NO_ANIM = A.NO_ANIM
CROSS JOIN (SELECT SUM(AC.DUREE*A.VENTE_HEURE) AS TOTAL FROM inscription I 
JOIN activite AC ON AC.JOUR = I.JOUR AND AC.NO_ATEL = I.NO_ATEL
JOIN atelier A ON A.NO_ATEL = AC.NO_ATEL
WHERE I.NO_ADHER = 6 ) tot 
WHERE AD.NO_ADHER=6

-- Sélectionner l’animateur qui a la meilleure moyenne

BEGIN
DECLARE @i INT = 1
WHILE @i < (SELECT MAX(NO_ADHER) FROM #PAIEME