<?php

$db = new mysqli('localhost', 'root', '', 'epsic_simulator');

if ($db->connect_errno) {
	printf("Failed to connect to database");
	exit();
}

//0 = $_GET['date'] ?? date("1971-01-01");
$json = [
	"categories" => [],
	"questions" => [],
	"answers" => []
];

$result = $db->query("SELECT * FROM categories WHERE id > '"."0"."'");
while ($row = $result->fetch_assoc()) {
	$json['categories'][] = $row;
}

$result = $db->query("SELECT * FROM questions WHERE id > '"."0"."'");
while ($row = $result->fetch_assoc()) {
	$json['questions'][] = $row;
}

$result = $db->query("SELECT * FROM answers WHERE id > '"."0"."'");
while ($row = $result->fetch_assoc()) {
	$json['answers'][] = $row;
}

header("Content-Type: application/json; charset=UTF-8");
echo str_replace("'", "''", json_encode($json));
