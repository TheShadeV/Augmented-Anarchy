<?php
$html = file_get_contents('../frontend/login/index.html');
// $html = str_replace('##SIKER##', '', $html);
// $html = str_replace('##ERROR##', '', $html);
echo $html;