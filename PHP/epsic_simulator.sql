-- phpMyAdmin SQL Dump
-- version 4.9.2
-- https://www.phpmyadmin.net/
--
-- Hôte : 127.0.0.1
-- Généré le :  mar. 10 mars 2020 à 22:19
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
(37, 12, 'On centre le mot', 0),
(38, 21, 'Integer', 0),
(39, 21, 'Float', 0),
(40, 21, 'String', 1),
(41, 21, 'Int', 0),
(42, 22, 'Integer', 1),
(43, 22, 'Float', 0),
(44, 22, 'String', 0),
(45, 22, 'Boolean', 0),
(46, 23, 'Integer', 0),
(47, 23, 'Float', 1),
(48, 23, 'String', 0),
(49, 23, 'Boolean', 0),
(50, 24, 'b + a', 0),
(51, 24, 'Salut', 0),
(52, 24, 'lutSa', 1),
(53, 24, 'ERROR', 0),
(54, 25, '12*4', 1),
(55, 25, '48', 0),
(56, 25, '48.0', 0),
(57, 25, 'ERROR', 0),
(58, 26, '12*4.0', 0),
(59, 26, '48', 0),
(60, 26, '48.0', 1),
(61, 26, 'ERROR', 0),
(62, 27, '5', 0),
(63, 27, '32', 0),
(64, 27, '\"3\" + 2', 0),
(65, 27, 'ERROR', 0),
(66, 28, 'Integer', 0),
(67, 28, 'Float', 0),
(68, 28, 'String', 1),
(69, 28, 'Boolean', 0),
(70, 29, '5', 1),
(71, 29, '32', 0),
(72, 29, 'ERROR', 0),
(73, 29, '3 + int(\"2\")', 0),
(74, 30, '5', 0),
(75, 30, '32', 1),
(76, 30, 'ERROR', 0),
(77, 30, '3 + \"2\"', 0);

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
(12, 'Excel', 10),
(13, 'Informatique', NULL),
(14, 'Programmation', 13),
(15, 'Python', 14);

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
(4, 'Un classeur Excel est constitué de…', 1, 12, NULL),
(5, 'Comment appelle-t-on les \"cases\" d\'un tableau Excel ?', 1, 12, NULL),
(6, 'Quel est le nom de la cellule sélectionnée ?', 1, 12, 'XL_Cellule.PNG'),
(7, 'Je dois additionner plusieurs nombres, quelle est la formule que je dois utiliser ?', 1, 12, NULL),
(8, 'Je dois multiplier plusieurs nombres, quelle est la formule que je dois utiliser ?', 1, 12, NULL),
(9, 'Je dois calculer un prix moyen, quelle est la formule que je dois utiliser ?', 1, 12, NULL),
(10, 'Sélectionnez une des formules qui renvoie 20', 1, 12, 'XL_Formule_Addition.webp'),
(11, 'Comment appelle-t-on ce type de graphique ?', 1, 12, 'XL_Graphique.webp'),
(12, 'Comment fait-on pour qu\'un mot soit réparti sur 3 cellules ?', 1, 12, NULL),
(21, 'Quel est le type de a ?', 1, 15, 'Python-type-1.png'),
(22, 'Quel est le type de a ?', 1, 15, 'Python-type-2.png'),
(23, 'Quel est le type de a ?', 1, 15, 'Python-type-3.png'),
(24, 'Quel est le résultat du script suivant ?', 1, 15, 'Python-type-4.png'),
(25, 'Quel est le résultat du script suivant ?', 1, 15, 'Python-type-5.png'),
(26, 'Quel est le résultat du script suivant ?', 1, 15, 'Python-type-6.png'),
(27, 'Quel est le résultat du script suivant ?', 1, 15, 'Python-type-7.png'),
(28, 'Quel est le type de a ?', 1, 15, 'Python-type-8.png'),
(29, 'Quel est le résultat du script suivant ?', 1, 15, 'Python-type-9.png'),
(30, 'Quel est le résultat du script suivant ?', 1, 15, 'Python-type-10.png');

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
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=78;

--
-- AUTO_INCREMENT pour la table `categories`
--
ALTER TABLE `categories`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=16;

--
-- AUTO_INCREMENT pour la table `questions`
--
ALTER TABLE `questions`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=31;

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
