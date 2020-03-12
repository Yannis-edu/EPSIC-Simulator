<?php

$db = new mysqli('localhost', 'root', '', 'epsic_simulator');

if ($db->connect_errno) {
	printf("Failed to connect to database");
	exit();
}

$result = $db->query("SELECT * FROM categories");
while ($row = $result->fetch_assoc()) {
	$categories[] = $row;
}

?>
<!DOCTYPE html>
<html>
	<head>
		<title>Inserer une question</title>
		<meta charset="utf-8">
		<meta name="viewport" content="width=device-width">
	</head>
	<body>
		<h2>Formulaire</h2>
		<form method="post">
			<label for="category">Catégorie :</label>
			<select name="category">
				<?php foreach($categories as $category){
					echo '<option value="'.$category['id'].'">'.$category['category'].'</option>';
				}?>
			</select><br>
			<label for="question">Question :</label>
			<textarea name="question"></textarea><br>
			<label for="points">Points :</label>
			<input type="number" name="points" step="any"><br>
			<label for="picture">Image :</label>
			<input type="text" name="picture"><br>
			<?php for($i = 0; $i < 4; $i++) {
				echo '<label for="answer['.$i.']">Réponse '.$i.' :</label>';
				echo '<input type="text" name="answer['.$i.']">';
				echo '<input type="checkbox" name="correct['.$i.']"><br>';
			} ?>
			<input type="submit" name="submit">
		</form>
	</body>
</html>
<?php

if(isset($_POST['submit'])){
	$db->query("INSERT INTO questions(question, points, fk_category, picture) VALUES('".str_replace("'", "''", $_POST['question'])."', ".$_POST['points'].", ".$_POST['category'].", '".$_POST['picture']."');");

	$question_id = $db->insert_id;
	for($i = 0; $i < count($_POST['answer']); $i++) {
		if(!empty($_POST['answer'][$i])){
			$db->query("INSERT INTO answers(fk_question, answer, correct) VALUES(".$question_id.", '".str_replace("'", "''", $_POST['answer'][$i])."', ".(empty($_POST['correct'][$i])?'0':'1').");");
		}
	}

	$db->close();
}