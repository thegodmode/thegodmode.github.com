<?php
get_header();
?>
<!-- >> BODY !-->
<div id="body" class="wrapper ">
	<?php
            wp_nav_menu( array(
                'theme_location'  => 'body-menu',
                'container'       => 'nav',
                'container_id'    => 'body-menu',
                'fallback_cb'     => 'default_body_menu',
                )
            ); ?>
	
	<div id="image-slider" >
		<div id="slider" class="slides">
			<div class="blueberry">
				<ul class="slides">
					
					<li>
						<img src="<?php echo get_template_directory_uri(); ?>/images/image-1.jpg" alt="image" />
					</li>
					<li>
						<img src="<?php echo get_template_directory_uri(); ?>/images/image-2.jpg" alt="image" />
					</li>
                    
				</ul>
			</div>
		</div>
	</div>
	
	<div id="post-shadow">
	     <?php 
	       $post_number=1;
           if(have_posts()){
                while (have_posts()){
                    if(in_category('MainPost',the_post())){
                
         ?>
		<div class="post clear">
			<span class="post-number"><?php echo $post_number?>.</span>
			<span class="post-title"> <?php the_title() ?> </span>
			<p class="post-inforamtion">
				Posted by <?php the_author()?> on <?php the_time('M'); ?>. <?php the_time('jS'); ?> <?php the_time('Y'); ?>
			</p>
			<div class="symbol">
				}
			</div>
			<div class="post-content expandable">
			    <?php the_content()?>
			</div>
		</div>
		<?php
		$post_number++;
                }
          }
        }
      if($post_number===1) { ?>
          <div class="post clear">
                    <span class="post-number">1.</span>
                    <span class="post-title"> Design Elegance </span>
                    <p class="post-inforamtion">
                        Posted by Admin on Jan. 15th 2008
                    </p>
                    <div class="symbol clear">
                        }
                    </div>
                    <div class="post-content expandable">
                        Lorem ipsum dolor sit amet, consectetueradipiscing elit. Sed libero purus, ultricies sed, pulvinar eu,ullamcorper eu, sapien. Pellentesque id lorem in nisl molestie viverra.Integer est massa, tincidunt quis, egestas et, lobortis et, risus. Fusce
                        orem ipsum dolor sit amet, consectetueradipiscing elit. Sed libero purus, ultricies sed, pulvinar eu,ullamcorper eu, sapien. Pellentesque id lorem in nisl molestie viverra.Integer est massa, tincidunt quis, egestas et, lobortis et, risus. Fusce
                        Lorem ipsum dolor sit amet, consectetueradipiscing elit. Sed libero purus, ultricies sed, pulvinar eu,ullamcorper eu, sapien. Pellentesque id lorem in nisl molestie viverra.Integer est massa, tincidunt quis, egestas et, lobortis et, risus. Fusce
                        orem ipsum dolor sit amet, consectetueradipiscing elit. Sed libero purus, ultricies sed, pulvinar eu,ullamcorper eu, sapien. Pellentesque id lorem in nisl molestie viverra.Integer est massa, tincidunt quis, egestas et, lobortis et, risus. Fusce
                        Lorem ipsum dolor sit amet, consectetueradipiscing elit. Sed libero purus, ultricies sed, pulvinar eu,ullamcorper eu, sapien. Pellentesque id lorem in nisl molestie viverra.Integer est massa, tincidunt quis, egestas et, lobortis et, risus. Fusce
                        orem ipsum dolor sit amet, consectetueradipiscing elit. Sed libero purus, ultricies sed, pulvinar eu,ullamcorper eu, sapien. Pellentesque id lorem in nisl molestie viverra.Integer est massa, tincidunt quis, egestas et, lobortis et, risus. Fusce
                        Lorem ipsum dolor sit amet, consectetueradipiscing elit. Sed libero purus, ultricies sed, pulvinar eu,ullamcorper eu, sapien. Pellentesque id lorem in nisl molestie viverra.Integer est massa, tincidunt quis, egestas et, lobortis et, risus. Fusce
                        orem ipsum dolor sit amet, consectetueradipiscing elit. Sed libero purus, ultricies sed, pulvinar eu,ullamcorper eu, sapien. Pellentesque id lorem in nisl molestie viverra.Integer est massa, tincidunt quis, egestas et, lobortis et, risus. Fusce
                        Lorem ipsum dolor sit amet, consectetueradipiscing elit. Sed libero purus, ultricies sed, pulvinar eu,ullamcorper eu, sapien. Pellentesque id lorem in nisl molestie viverra.Integer est massa, tincidunt quis, egestas et, lobortis et, risus. Fusce
                        orem ipsum dolor sit amet, consectetueradipiscing elit. Sed libero purus, ultricies sed, pulvinar eu,ullamcorper eu, sapien. Pellentesque id lorem in nisl molestie viverra.Integer est massa, tincidunt quis, egestas et, lobortis et, risus. Fusce

                    </div>
                </div>
    <?php
      }
    ?>
	</div>
	
	<div id="mini-image-contaner" class="clear">
        <?php if(!dynamic_sidebar('gallery-image-slider')){ ?>
		<a class="grouped_elements" rel="group1" href="<?php echo get_template_directory_uri(); ?>/images/1_b.jpg"><img src="<?php echo get_template_directory_uri(); ?>/images/1_b.jpg" alt=""  class='mini-image' title="Click to View images in slidemod"/></a>
		<a class="grouped_elements" rel="group1" href="<?php echo get_template_directory_uri(); ?>/images/2_b.jpg"><img src="<?php echo get_template_directory_uri(); ?>/images/2_b.jpg" alt=""  class='mini-image' title="Click to View images in slidemod"/></a>
        <?php } ?>
	</div>
	<section id="section">
	    <?php 
           $bool = false;
           if(have_posts()){
                while (have_posts()){
                    if(in_category('Article',the_post())){
                      $bool=true;
         ?>
		<article class="article">
		   <?php if ( has_post_thumbnail() ) {
                  the_post_thumbnail();
                    } 
                    else
                    { ?>
            <img src="<?php echo get_template_directory_uri(); ?>/images/Chrysanthemum.jpg" alt="image"/>
                    <?php } ?>
			<span class="article-title"><?php the_title() ?></span>
			<div class="article-content">
				<?php the_content(); ?>
			</div>
		</article>
		<?php
             }
          }
        }
        if(!$bool){ ?>
            
            <article class="article">
            <img src="<?php echo get_template_directory_uri(); ?>/images/Chrysanthemum.jpg" alt="image"/>
            <span class="article-title">Article Title </span>
            <div class="article-content">
                Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Nullam urna augue, pulvinar pulvinar, viverra vel, suscipit. Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Nullam urna augue, pulvinar pulvinar. Nullam urna augue, pulvinar pulvinar
            </div>
        </article>
        <article class="article">
            <img src="<?php echo get_template_directory_uri(); ?>/images/Chrysanthemum.jpg" alt="image"/>
            <span class="article-title">Article Title</span>
            <div class="article-content">
                Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Nullam urna augue, pulvinar pulvinar, viverra vel, suscipit. Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Nullam urna augue, pulvinar pulvinar. Nullam urna augue, pulvinar pulvinar
            </div>
        </article>
        <article class="article">
            <img src="<?php echo get_template_directory_uri(); ?>/images/Chrysanthemum.jpg" alt="image"/>
            <span class="article-title">Article Title</span>
            <div class="article-content">
                Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Nullam urna augue, pulvinar pulvinar, viverra vel, suscipit. Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Nullam urna augue, pulvinar pulvinar. Nullam urna augue, pulvinar pulvinar
            </div>
        </article>
        <?php } ?>
		<div class="bottom-<?php echo get_template_directory_uri(); ?>/images">
			<img src="<?php echo get_template_directory_uri(); ?>/images/perl.png" id='perl' alt="image"/>
			<img src="<?php echo get_template_directory_uri(); ?>/images/perl-shadow.png" id='perl-shadow' alt="image"/>
		</div>
	</section>

	<aside id="tabs-holder" class="clear">
	  <?php if(!dynamic_sidebar('tab-1')){ ?> 
		<div class="tab-container">
			<div class="tabs">
			  	<ul>
					<li>
					    
						<a href="#Aboutus" title="About us">About us</a>
						
					</li>

				</ul>
				<div class="tab-content" id="Aboutus">
					<div>
						Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Nullam urna augue, pulvinar pulvinar, viverra vel, suscipit. Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Nullam urna augue, pulvinar pulvinar, viverra vel, suscipit Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Nullam urna augue, pulvinar pulvinar, viverra vel, suscipit. Lorem ipsum dolor sit amet, con
					</div>

				</div>

			</div>
		</div>
		<?php } ?>
		<?php if(!dynamic_sidebar('tab-2')){ ?> 
		<div class="tab-container">
			<div class="tabs">
				<ul>
					<li>
						<a href="#Comments" title="Comments">Comments</a>
					</li>
					<li>
						<a href="#Popular" title="Popular">Popular</a>
					</li>
					<li>
						<a href="#Random" title="Random">Random</a>
					</li>

				</ul>
				<div class="tab-content" id="Comments">
					<ul>
						<li>
							<a href="#">Test from Denmark on Nam libero tempore, cum soluta nobis est</a>
						</li>
						<li>
							<a href="#">admin on Ut sagittis ultrices urna eget erat non purus varius</a>
						</li>
						<li>
							<a href="#">admin on Nam libero tempore, cum soluta nobis est</a>
						</li>
						<li>
							<a href="#">admin on Neque porro quisquam est, qui dolorem ipsum</a>
						</li>
						<li>
							<a href="#">admin on Nulla tincidunt lorem imperdiet interdum dolor</a>
						</li>
					</ul>
				</div>
				<div class="tab-content" id="Popular">
					<ul>
						<li>
							<a href="#"> from Denmark on Nam libero tempore, cum soluta nobis est</a>
						</li>
						<li>
							<a href="#">admin on Ut sagittis ultrices urna eget erat non purus varius </a>
						</li>
						<li>
							<a href="#">admin on Nam libero tempore, cum soluta nobis est</a>
						</li>
						<li>
							<a href="#">admin on Neque porro quisquam est, qui dolorem ipsum</a>
						</li>
						<li>
							<a href="#">admin on Nulla tincidunt lorem imperdiet interdum dolor</a>
						</li>
					</ul>
				</div>
				<div class="tab-content" id="Random">
					<ul>
						<li>
							<a href="#"> from Denmark on Nam libero tempore, cum soluta nobis est</a>
						</li>
						<li>
							<a href="#">admin on Ut sagittis ultrices urna eget erat non purus varius</a>
						</li>
						<li>
							<a href="#">admin on Nam libero tempore, cum soluta nobis est</a>
						</li>
						<li>
							<a href="#">admin on Neque porro quisquam est, qui dolorem ipsum</a>
						</li>
						<li>
							<a href="#">admin on Nulla tincidunt lorem imperdiet interdum dolor</a>
						</li>
					</ul>
				</div>
			</div>
		</div>
		<?php } ?>
		<div id="bottom-border" >
			<img src="<?php echo get_template_directory_uri(); ?>/images/tabs-holder-bottom-border.png" alt="image"/>
		</div>
	</aside>
</div>
<!-- << BODY !-->
<?php
get_footer();
?>
