<?php

$db = new mysqli('localhost', 'root', '', 'epsic_simulator');

if ($db->connect_errno) {
	printf("Failed to connect to database");
	exit();
}

$timestamp = $_GET['date'] ?? date("1971-01-01");
$json = [
	"questions" => [],
	"answers" => [],
	"questions_answers" => [],
	"categories" => [],
	"questions_categories" => [],
	"sub_categories" => [],
	"questions_sub_categories" => []
];

$result = $db->query("SELECT * FROM t_questions WHERE date_question > '".$timestamp."'");
while ($row = $result->fetch_assoc()) {
	$json['questions'][] = [
		"id" => $row['id_question'],
		"question" => $row['Nom_question'],
		"image_path" => $row['path_image_question'],
		"date_insert" => $row['date_question']
	];
}

$result = $db->query("SELECT * FROM t_reponses WHERE date_depose_reponse > '".$timestamp."'");
while ($row = $result->fetch_assoc()) {
	$json['answers'][] = [
		"id" => $row['id_reponse'],
		"answer" => $row['Reponse'],
		"image_path" => $row['path_image_reponse'],
		"source_answer" => $row['Source_reponse'],
		"points" => $row['Nb_Pts_Reponse'],
		"date_insert" => $row['Date_Depose_Reponse']
	];
}

$result = $db->query("SELECT * FROM t_corr_quest_rep WHERE date_insert_qr > '".$timestamp."'");
while ($row = $result->fetch_assoc()) {
	$json['questions_answers'][] = [
		"id" => $row['id_t_corr_quest_rep'],
		"fk_question" => $row['FK_QUESTION_QR'],
		"fk_answer" => $row['FK_REPONSE_QR'],
		"date_insert" => $row['date_insert_qr']
	];
}

$result = $db->query("SELECT * FROM t_categories WHERE date_category > '".$timestamp."'");
while ($row = $result->fetch_assoc()) {
	$json['categories'][] = [
		"id" => $row['id_categorie'],
		"category_folder" => $row['Name_folder_cat'],
		"category_name" => empty($row['Name_category']) ? $row['Nom_categorie'] : $row['Name_category'],
		"date_insert" => $row['date_category']
	];
}

$result = $db->query("SELECT * FROM t_quest_categories WHERE date_quest_categorie > '".$timestamp."'");
while ($row = $result->fetch_assoc()) {
	$json['questions_categories'][] = [
		"id" => $row['id_T_Quest_Categories'],
		"fk_question" => $row['fk_question'],
		"fk_category" => $row['fk_categorie'],
		"date_insert" => $row['Date_Quest_Categorie']
	];
}

$result = $db->query("SELECT * FROM t_sous_categorie WHERE date_subcategory > '".$timestamp."'");
while ($row = $result->fetch_assoc()) {
	$json['sub_categories'][] = [
		"id" => $row['Id_Sous_Categorie'],
		"sub_category_name" => empty($row['Name_Sub_category']) ? $row['Nom_Sous_Categorie'] : $row['Name_Sub_category'],
		"date_insert" => $row['date_subcategory']
	];
}

$result = $db->query("SELECT * FROM t_question_souscat WHERE date_quest_sous_categorie > '".$timestamp."'");
while ($row = $result->fetch_assoc()) {
	$json['questions_sub_categories'][] = [
		"id" => $row['Id_Question_SousCat'],
		"fk_question" => $row['FK_QUESTION_QR'],
		"fk_sub_category" => $row['fk_sous_categorie'],
		"date_insert" => $row['Date_Quest_Sous_Categorie']
	];
}

header("Content-Type: application/json; charset=UTF-8");
echo str_replace("'", "''", json_encode($json));
