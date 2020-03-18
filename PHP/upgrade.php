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
echo str_replace("'", "''", json_encode(utf8ize($json)));

function utf8ize($d) {
	if (is_array($d)) {
		foreach ($d as $k => $v) {
			$d[$k] = utf8ize($v);
		}
	} else if (is_string ($d)) {
		return utf8_encode($d);
	}
	return $d;
}