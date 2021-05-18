# AmphiQuizz

## Contexte de la réalisation de ce projet

Ce projet a été réalisé dans le cadre d'un TP de conception orientée objet à l'IUT d'Annecy.

## Sujet 

Afin de pouvoir ajouter de l’interaction aux cours magistraux, il a été décidé de
mettre en place une application informatique. Cette application, composée d’une seule
fenêtre, sera utilisée par les professeurs et permettra de consulter la liste des élèves, tirer
aléatoirement une élève ou sélectionner un élève pour un/des groupe/s pouvant être
préalablement choisis (tous les groupes sont choisis par défaut). Une fois l’élève tiré ou
sélectionné, son nom, son prénom, son groupe et son portrait devront s’afficher. Le
professeur pourra poser une question à l’élève et le noter. Cette note, qui est fonction du
professeur et de la date, peut s’échelonner de 0 à 2 : 0-absent, 1-mauvaise réponse ou
pas de réponse, 2-bonne réponse. Les notes devront toutes être conservées et pourront
être consultées depuis la même fenêtre.

Aucune historisation, d’une année à l’autre, n’est prévue. L’application sera développée sur
un mode « déconnecté » : pour un professeur, il n’est pas besoin d’avoir, à un instant t,
les toutes dernières notes ajoutées par un autre professeur. En effet, les cours magistraux
ne peuvent pas se dérouler en parallèle. Ainsi, les données (référentiels et liaisons entre
les référentiels) seront chargées au lancement de l’application, et seules les notes créées
par l’application seront insérées en base de données à la volée.
