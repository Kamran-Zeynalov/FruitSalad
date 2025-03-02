$(document).ready(function () {
  $(".hamburger-icon").on("click", function () {
    $(".side-menu").addClass("animate__animated animate__fadeInRight");
    $(".side-menu").removeClass("animate__fadeOutRight");
    $(".side-menu").css("visibility", "visible");
    $(".side-basket").removeClass("animate__fadeOutRight");
    $(".acordion").slideUp();
    $(".search-input").slideUp();
    $(".person-info").slideUp();
  });
  $(".menu-title").on("click", function () {
    $(".side-menu").addClass("animate__fadeOutRight");
  });
  $(".basket-icon").on("click", function () {
    $(".side-basket").addClass("animate__animated animate__fadeInRight");
    $(".side-basket").removeClass("animate__fadeOutRight");
    $(".side-basket").css("visibility", "visible");
    $(".acordion").slideUp();
    $(".side-menu").fadeOut();
    $(".search-input").slideUp();
    $(".person-info").slideUp();
  });
  $(".menu-title").on("click", function () {
    $(".side-basket").addClass("animate__fadeOutRight");
   
  });

  $(".categories-li").on("click", function () {
    $(".acordion").slideToggle();
    $(".account-acordion").slideUp();
  });
  $(".account-li").on("click", function () {
    $(".account-acordion").slideToggle();
    $(".acordion").slideUp();
  });
  $(".search-icon").on("click", function () {
    $(".search-input").slideToggle();
    $(".acordion").slideUp();
    $(".person-info").slideUp();
  });
  $(".person-icon").on("click", function () {
    $(".person-info").slideToggle();
    $(".acordion").slideUp();
    $(".search-input").slideUp();
  });
});
