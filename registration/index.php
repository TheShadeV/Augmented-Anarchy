<?php
$html = file_get_contents('templates/index.tpl');
$html = str_replace('##SIKER##', '', $html);
$html = str_replace('##ERROR##', '', $html);
echo $html;
?>