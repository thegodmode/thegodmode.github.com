<?php
/** Tell WordPress to run yourtheme_setup() when the 'after_setup_theme' hook is run. */
add_action( 'after_setup_theme', 'yourtheme_setup' );
if ( ! function_exists('yourtheme_setup') ):
/**
* @uses add_custom_image_header() To add support for a custom header.
* @uses register_default_headers() To register the default custom header images provided with the theme.
*
* @since 3.0.0
*/
function yourtheme_setup() {
// This theme uses post thumbnails
add_theme_support( 'post-thumbnails' );
// Your changeable header business starts here
define( 'HEADER_TEXTCOLOR', '' );
// No CSS, just IMG call. The %s is a placeholder for the theme template directory URI.
define( 'HEADER_IMAGE', '%s/images/Logos/Logo.png' );
// The height and width of your custom header. You can hook into the theme's own filters to change these values.
// Add a filter to yourtheme_header_image_width and yourtheme_header_image_height to change these values.
define( 'HEADER_IMAGE_WIDTH', apply_filters( 'yourtheme_header_image_width', 228 ) );
define( 'HEADER_IMAGE_HEIGHT', apply_filters( 'yourtheme_header_image_height',  56 ) );
// We'll be using post thumbnails for custom header images on posts and pages.
// We want them to be 940 pixels wide by 198 pixels tall (larger images will be auto-cropped to fit).
set_post_thumbnail_size( HEADER_IMAGE_WIDTH, HEADER_IMAGE_HEIGHT, true );
// Don't support text inside the header image.
define( 'NO_HEADER_TEXT', true );
// Add a way for the custom header to be styled in the admin panel that controls
// custom headers. See yourtheme_admin_header_style(), below.
add_custom_image_header( '', 'yourtheme_admin_header_style' );
// … and thus ends the changeable header business.
// Default custom headers packaged with the theme. %s is a placeholder for the theme template directory URI.
register_default_headers( array (
'american_floors' => array (
'url' => '%s/images/Logos/Logo1.png',
'thumbnail_url' => '%s/images/Logos/Logo1.png',
'description' => __( 'American floors', 'yourtheme' )
),
'bigpond' => array (
'url' => '%s/images/Logos/Logo2.png',
'thumbnail_url' => '%s/images/Logos/Logo2.png',
'description' => __( 'Big-Pond', 'yourtheme' )
),
'tvtorrents' => array (
'url' => '%s/images/Logos/Logo3.png',
'thumbnail_url' => '%s/images/Logos/Logo3.png',
'description' => __( 'Tv-torrents', 'yourtheme' )
),

) );
}
endif;
if ( ! function_exists( 'yourtheme_admin_header_style' ) ) :
/**
* Styles the header image displayed on the Appearance > Header admin panel.
*
* Referenced via add_custom_image_header() in yourtheme_setup().
*
* @since 3.0.0
*/
function yourtheme_admin_header_style() {
?>
<style type="text/css">
#headimg {
height: <?php echo HEADER_IMAGE_HEIGHT; ?>px;
width: <?php echo HEADER_IMAGE_WIDTH; ?>px;
}
#headimg h1, #headimg #desc {
display: none;
}
</style>
<?php
}
endif;
?>
<?php 
function default_main_menu() {
     ?><nav id="main-menu">
                <ul>
                    <li>
                        <a href="#" title="about">about </a>
                    </li>
                    <li>
                        <a href="#" title="contact">contact</a>
                    </li>
                    <li>
                        <a href="#" title="sitemap">sitemap</a>
                    </li>
                    <li>
                        <a href="#" title="testimonials">testimonials</a>
                    </li>
                    <li>
                        <a href="#" title="location">location</a>
                    </li>
                    <li>
                        <a href="#" title="portfolio">portfolio</a>
                    </li>
                    <li>
                        <a href="#" title="pricing">pricing</a>
                    </li>

                </ul>
        </nav><?php
        };
    ?>
    
 <?php 
function default_body_menu() {
     ?>  <nav id="body-menu">
        <ul>
            <li>
                <a href="#" title="about">about</a>
            </li>
            <li>
                <a href="#" title="contact">contact</a>
            </li>
            <li>
                <a href="#" title="sitemap">sitemap</a>
            </li>
            <li>
                <a href="#" title="testimonials">testimonials</a>
            </li>
            <li>
                <a href="#" title="location">location</a>
            </li>
            <li>
                <a href="#" title="portfolio">portfolio</a>
            </li>
            <li>
                <a href="#" title="pricing">pricing</a>
            </li>

        </ul>
    </nav><?php
    };
?>   
  
<?php
/** Registe menus **/
register_nav_menus(array('main-menu' => 'Main Menu', 'body-menu' => 'Sub Menu'));

//thjs will be run for each menu item
add_filter('nav_menu_css_class', 'cssattr_filter', 100, 1);

function cssattr_filter($var) {
    if (!is_array($var))
        return;

    $current_indicators = array('current-menu-item', 'current-menu-parent', 'current_page_item', 'current_page_parent');

    $newArr = array();
    foreach ($var as $el) {
        //check if it contains an ID or it's indicating the current page
        if ((preg_match('#[0-9]#', $el)) || in_array($el, $current_indicators)) {
            array_push($newArr, $el);
        }
    }

    return $newArr;
}
/* Register sidebar  */
register_sidebar(array(
'name' => __( 'Image-Slider' ),
'id' => 'main-image-slider',
'description' => __( 'Widgets in this area will add images in image slider.It work only with "IMAGE WIDGET!"' ),
'before_widget' => '',
'after_widget' => ''
));

/* Register sidebar  */
register_sidebar(array(
'name' => __( 'Image-Gallery' ),
'id' => 'gallery-image-slider',
'description' => __( 'Widgets in this area will add images in image gallery.It work only with "REALLY SIMPLE GALLERY WIDGET!"' ),
'before_widget' => '',
'after_widget' => ''
));
/* Register sidebar  */
register_sidebar(array(
'name' => __( 'Footer' ),
'id' => 'footers',
'description' => __( 'Add Footer Text!' ),
'before_widget' => '',
'after_widget' => ''
));
/* Register sidebar  */
register_sidebar(array(
'name' => __( 'Tab-1' ),
'id' => 'tab-1',
'description' => __( 'Use "TEXT WIDGET" to Add Tabs! Dont use Titles' ),
'before_widget' => '',
'after_widget' => ''
));
/* Register sidebar  */
register_sidebar(array(
'name' => __( 'Tab-2' ),
'id' => 'tab-2',
'description' => __( 'Use "TEXT WIDGET" to Add Tabs! Dont use Titles' ),
'before_widget' => '',
'after_widget' => ''
));

// Support Featured Image
add_theme_support( 'post-thumbnails' ); 
