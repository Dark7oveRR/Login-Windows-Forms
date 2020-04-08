<?php
  $con = mysqli_connect("host", "username", "password", "DataBase Name");
  if(!$con) {
    die("noconn");
  }
  $user_username = "";
  $user_password = "";
  if(isset($_POST['user_username']) && !empty($_POST['user_username']) && isset($_POST['user_password']) && !empty($_POST['user_password'])) {
    $user_username = mysqli_real_escape_string($con, $_POST['user_username']);
    $user_password = mysqli_real_escape_string($con, $_POST['user_password']);
    $user_password = md5($user_password);
  }
  elseif(isset($_GET['user_username']) && !empty($_GET['user_username']) && isset($_GET['user_password']) && !empty($_GET['user_password'])) {
    $user_username = mysqli_real_escape_string($con, $_GET['user_username']);
    $user_password = mysqli_real_escape_string($con, $_GET['user_password']);
    $user_password = md5($user_password);
  } else {
    die("nodata");
  }
  $query_login = $con->Query("SELECT user_password, user_banned FROM users WHERE user_username = '".$user_username."' LIMIT 1");
  if(!$query_login) {
    die("dataerror");
  }
  elseif($query_login->num_rows != 1) {
    die("usernotfound");
  } else {
    $query_result = $query_login->Fetch_assoc();
    if($user_password != $query_result['user_password']) {
      die("userwrongpassword");
    }
    elseif($query_result['user_banned'] == 1) {
      die("userbanned");
    } else {
      die("success");
    }
  }
?>