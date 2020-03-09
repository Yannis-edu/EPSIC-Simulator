-- phpMyAdmin SQL Dump
-- version 4.9.2
-- https://www.phpmyadmin.net/
--
-- Hôte : 127.0.0.1
-- Généré le :  lun. 09 mars 2020 à 17:40
-- Version du serveur :  10.4.11-MariaDB
-- Version de PHP :  7.4.1

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET AUTOCOMMIT = 0;
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Base de données :  `epsic_simulator`
--

-- --------------------------------------------------------

--
-- Structure de la table `answers`
--

CREATE TABLE `answers` (
  `id` int(11) NOT NULL,
  `fk_question` int(11) NOT NULL,
  `answer` varchar(255) NOT NULL,
  `correct` tinyint(1) NOT NULL DEFAULT 0
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Déchargement des données de la table `answers`
--

INSERT INTO `answers` (`id`, `fk_question`, `answer`, `correct`) VALUES
(1, 3, 'Un classeur', 1),
(2, 3, 'Un document', 0),
(3, 3, 'Une feuille', 0),
(4, 3, 'Une page', 0),
(5, 4, 'Pages', 0),
(6, 4, 'Feuilles', 1),
(7, 4, 'Pochettes', 0),
(8, 4, 'Listes', 0),
(9, 5, 'Des cases', 0),
(10, 5, 'Des rectangles', 0),
(11, 5, 'Des cellules', 1),
(12, 5, 'Des zones', 0),
(13, 6, 'A1', 0),
(14, 6, 'E11', 1),
(15, 6, '11E', 0),
(16, 6, '1A', 0),
(17, 7, 'SOMME', 1),
(18, 7, 'PRODUIT', 0),
(19, 7, 'MOYENNE', 0),
(20, 8, 'SOMME', 0),
(21, 8, 'PRODUIT', 1),
(22, 8, 'MOYENNE', 0),
(23, 9, 'SOMME', 0),
(24, 9, 'PRODUIT', 0),
(25, 9, 'MOYENNE', 1),
(26, 10, '=SOMME(D3:D6)', 1),
(27, 10, '=D3+D4+D5+D6', 0),
(28, 10, 'D3+D4+D5+D6', 0),
(29, 10, '=SOMME(D3;D4;D5;D6)', 0),
(30, 11, 'Un camembert', 0),
(31, 11, 'Un graphique en secteurs', 1),
(32, 11, 'Un diagramme', 0),
(33, 11, 'Un histogramme', 0),
(34, 12, 'On fusionne les cellules', 1),
(35, 12, 'On change la taille des colonnes', 0),
(36, 12, 'On encadre les cellules', 0),
(37, 12, 'On centre le mot', 0);

-- --------------------------------------------------------

--
-- Structure de la table `categories`
--

CREATE TABLE `categories` (
  `id` int(11) NOT NULL,
  `category` varchar(255) NOT NULL,
  `fk_parent` int(11) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Déchargement des données de la table `categories`
--

INSERT INTO `categories` (`id`, `category`, `fk_parent`) VALUES
(10, 'Bureautique', NULL),
(12, 'Excel', 10);

-- --------------------------------------------------------

--
-- Structure de la table `questions`
--

CREATE TABLE `questions` (
  `id` int(11) NOT NULL,
  `question` text NOT NULL,
  `points` float NOT NULL,
  `fk_category` int(11) NOT NULL,
  `picture` varchar(255) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Déchargement des données de la table `questions`
--

INSERT INTO `questions` (`id`, `question`, `points`, `fk_category`, `picture`) VALUES
(3, 'Comment appelle-t-on un fichier Excel ?', 1, 12, NULL),
(4, 'Un classeur excel est constitué de…', 1, 12, NULL),
(5, 'Comment appelle-t-on les \"cases\" d\'un tableau excel ?', 1, 12, NULL),
(6, 'Quel est le nom de la cellule sélectionnée ?', 1, 12, 'XL_Cellule.PNG'),
(7, 'Je dois additionner plusieurs nombres, quelle est la formule que je dois utiliser ?', 1, 12, NULL),
(8, 'Je dois multiplier plusieurs nombres, quelle est la formule que je dois utiliser ?', 1, 12, NULL),
(9, 'Je dois calculer un prix moyen, quelle est la formule que je dois utiliser ?', 1, 12, NULL),
(10, 'Sélectionnez une des formules qui renvoie 20', 1, 12, 'XL_Formule_Addition.webp'),
(11, 'Comment appelle-t-on ce type de graphique ?', 1, 12, 'XL_Graphique.webp'),
(12, 'Comment fait-on pour qu\'un mot soit réparti sur 3 cellules ?', 1, 12, NULL);

--
-- Index pour les tables déchargées
--

--
-- Index pour la table `answers`
--
ALTER TABLE `answers`
  ADD PRIMARY KEY (`id`),
  ADD KEY `fk_question` (`fk_question`);

--
-- Index pour la table `categories`
--
ALTER TABLE `categories`
  ADD PRIMARY KEY (`id`),
  ADD KEY `fk_parent` (`fk_parent`);

--
-- Index pour la table `questions`
--
ALTER TABLE `questions`
  ADD PRIMARY KEY (`id`),
  ADD KEY `fk_category` (`fk_category`);

--
-- AUTO_INCREMENT pour les tables déchargées
--

--
-- AUTO_INCREMENT pour la table `answers`
--
ALTER TABLE `answers`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=38;

--
-- AUTO_INCREMENT pour la table `categories`
--
ALTER TABLE `categories`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=13;

--
-- AUTO_INCREMENT pour la table `questions`
--
ALTER TABLE `questions`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=13;

--
-- Contraintes pour les tables déchargées
--

--
-- Contraintes pour la table `answers`
--
ALTER TABLE `answers`
  ADD CONSTRAINT `answers_ibfk_1` FOREIGN KEY (`fk_question`) REFERENCES `questions` (`id`);

--
-- Contraintes pour la table `categories`
--
ALTER TABLE `categories`
  ADD CONSTRAINT `categories_ibfk_1` FOREIGN KEY (`fk_parent`) REFERENCES `categories` (`id`);

--
-- Contraintes pour la table `questions`
--
ALTER TABLE `questions`
  ADD CONSTRAINT `questions_ibfk_1` FOREIGN KEY (`fk_category`) REFERENCES `categories` (`id`);
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
