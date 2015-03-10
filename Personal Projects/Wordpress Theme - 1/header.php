<!DOCTYPE html>
  <html  <?php language_attributes(); ?>>
	<head>
		<meta charset="<?php bloginfo('charset'); ?>" />
		<meta name="autor" content="Bozhidar Penchev"/>
		<meta name="description" content="<?php bloginfo('description'); ?>"/>
		<title><?php
        /*
         * Print the <title> tag based on what is being viewed.
         */
        global $page, $paged;

        wp_title('-', true, 'right');

        // Add the blog name.
        bloginfo('name');

        // Add the blog description for the home/front page.
        $site_description = get_bloginfo('description', 'display');
        if ($site_description && (is_home() || is_front_page()))
            echo " - $site_description";

        // Add a page number if necessary:
        if ($paged >= 2 || $page >= 2)
            echo ' - ' . sprintf(__('Page %s', 'twentyten'), max($paged, $page));
    ?></title>	
	  <link href="<?php echo bloginfo('stylesheet_url'); ?>" type="text/css" rel="stylesheet">
	  <link rel="shortcut icon" href="<?php echo bloginfo('stylesheet_url');?>/images/favicon.ico">
	</head>
	<body>
		<!-- >> HEAD !-->
		<header id="header" class="wrapper">
			<h1><a href="<?php echo home_url( '/' ) ?>"> <?php
			// Check if this is a post or page, if it has a thumbnail, and if it's a big one
			if ( is_singular() &&
			has_post_thumbnail( $post->ID ) &&
			( /* $src, $width, $height */ $image = wp_get_attachment_image_src( get_post_thumbnail_id( $post->ID ), 'post-thumbnail') ) &&
			$image[1] >= HEADER_IMAGE_WIDTH ) :
			// We have a new header image!
			echo get_the_post_thumbnail( $post->ID, 'post-thumbnail' );
			else : ?> <img src="<?php header_image(); ?>" id="logo"  alt="<?php bloginfo('name'); echo" Logo";?>" title="<?php bloginfo('name');?>" /> <?php endif; ?> </a></h1>
			<?php
			wp_nav_menu( array(
                'theme_location'  => 'main-menu',
                'container'       => 'nav',
                'container_id'    => 'main-menu',
                'fallback_cb'     => 'default_main_menu',
                )
            ); ?>
		</header>
<!-- << HEAD !-->
