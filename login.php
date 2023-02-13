<?PHP
$loggin = $_GET['login'];
$password = $_GET['password'];
$link = mysqli_connect("127.0.0.1", "root", "", "mining_farm_db");

if (!$link) {
    echo "Ошибка: Невозможно установить соединение с MySQL." . PHP_EOL;
    echo "Код ошибки errno: " . mysqli_connect_errno() . PHP_EOL;
    echo "Текст ошибки error: " . mysqli_connect_error() . PHP_EOL;
    exit;
}
$check = mysqli_query($link,"SELECT * FROM users WHERE `Login`='".$loggin."'");
$check1 = mysqli_query($link,"SELECT * FROM users WHERE `Password`='".$password."'");
$numrows = mysqli_num_rows($check);
$numrows1= mysqli_num_rows($check1);
$permitted_chars = '0123456789abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ';
function generate_string($input, $strength = 16) {
    $input_length = strlen($input);
    $random_string = '';
    for($i = 0; $i < $strength; $i++) {
        $random_character = $input[mt_rand(0, $input_length - 1)];
        $random_string .= $random_character;
    }
    return $random_string;
}
if ($numrows == 0)
{
	$chec = mysqli_query($link,"INSERT INTO users Values('','".$loggin."','".md5($password)."','".generate_string($permitted_chars, 10)."',100,1,0,0,4)");
    $query="SELECT ID from users where `Login`='".$loggin."' and `Password`='".md5($password)."'";
    $check = mysqli_query($link,$query);
    while($rowData = mysqli_fetch_row($check)){
        printf("%s\n", $rowData[0]);
  }}
else
{
    $query="SELECT ID from users where `Login`='".$loggin."' and `Password`='".md5($password)."'";
    $check = mysqli_query($link,$query);
    while($rowData = mysqli_fetch_row($check)){
        printf("%s\n", $rowData[0]);
  }}


