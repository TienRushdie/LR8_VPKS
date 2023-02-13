<?PHP
$nick=$_POST['nick'];
$money = $_POST['money'];
$t1c=$_POST['t1c'];
$t2c=$_POST['t2c'];
$t3c=$_POST['t3c'];
$cap=$_POST['cap'];
$link = mysqli_connect("127.0.0.1", "root", "", "mining_farm_db");

if (!$link) {
    echo "Ошибка: Невозможно установить соединение с MySQL." . PHP_EOL;
    echo "Код ошибки errno: " . mysqli_connect_errno() . PHP_EOL;
    echo "Текст ошибки error: " . mysqli_connect_error() . PHP_EOL;
    exit;
}
$check = mysqli_query($link,"UPDATE users SET Balance = '".$money."',type_1_cards='".$t1c."',type_2_cards='".$t2c."',type_3_cards='".$t3c."',Capacity='".$cap."' WHERE (NickName='".$nick."')");

?>