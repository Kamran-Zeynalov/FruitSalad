$(document).ready(function () {
//   $(".title-categories .title").on("click", function () {
//     var section = $(this).closest(".title-categories");
//     section.find(".categories, .calories, .taste, .season").slideToggle();
//     $(".title-categories .categories,.title-categories .calories,.title-categories .taste,.title-categories .season").not(section.find(".categories, .calories, .taste, .season")).slideUp();
//   });

   $(".fruitButton button").on("click", function () {
    $(this).toggleClass("secondButton");
  //   fetch('/shop')
  //               .then(response => response.json())
  //               .then(data => {
  //                   document.getElementById('dicc').innerText = data.message;
  //               })
  //               .catch(error => {
  //                   console.error('Hata:', error);
  //               });
        
   });
});
