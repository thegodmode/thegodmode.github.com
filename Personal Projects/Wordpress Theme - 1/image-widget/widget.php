<?php
/**
 * Widget template. This template can be overriden using the "sp_template_image-widget_widget.php" filter.
 * See the readme.txt file for more info.
 */

// Block direct requests
if ( !defined('ABSPATH') )
	die('-1');

echo $before_widget;
if ( !empty( $image ) ) {
	if ( $link ) {
		echo '<li>';
	}
	if ( $imageurl ) {
		echo '<img src="'.esc_url($imageurl).'"';
		if ( !empty( $width ) && is_numeric( $width ) ) {
			echo "";
		}
		if ( !empty( $alt ) ) {
			$alt = esc_attr($alt);
			echo " alt=\"{$alt}\"";
		} else {
			$title = esc_attr($title);
			echo " alt=\"{$title}\"";					
		}
		echo " />";
	}

	if ( $link ) { echo '</a></li>'; }
}
if ( !empty( $description ) ) {
	$text = apply_filters( 'widget_text', $description, $args, $instance );
	echo '<div class="'.$this->widget_options['classname'].'-description" >';
	echo wpautop( $text );			
	echo "</div>";
}
echo $after_widget;
?>