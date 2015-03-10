<!-- >> FOOTER !-->
        <footer class="wrapper">
            <div id="footer-content">
                 <?php if(!dynamic_sidebar('footers')){ ?>
                Telerik Academy Web Design Course
                <?php } ?>
            </div>
        </footer>
        <!-- << FOOTER !-->
        <script src="https://ajax.googleapis.com/ajax/libs/jquery/1.7.2/jquery.min.js"></script>
        <script  src="<?php echo get_template_directory_uri(); ?>/scripts/plugins.js" type="text/javascript"></script>
        <script  src="<?php echo get_template_directory_uri(); ?>/scripts/script.js" type="text/javascript"></script>
    </body>
</html>
