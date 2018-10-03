function chercherPersonnage(idpersonnage) {
  jQuery('#idarea').html("");
 
  jQuery.ajax({
      method: "GET",
      url: "https://swapi.co/api/people/?page=" + idpersonnage + ""
    })
    .done(function(data) {
      liste = data["results"];
      liste.forEach(function(item) {
        var div1 = jQuery('<div id="perso" class="col-sm-6 col-md-4 perso" >');
        var titre = jQuery('<h2 id="h2pers">' + item.name + '</h2>');
        var date = jQuery('<ul> Année de Naissance : ' + item.birth_year + '</ul>');
        var poids = jQuery('<ul> Poids : ' + item.mass + ' kgs </ul>');
        var films = jQuery('<ul class="films"> Episodes : </br> </ul>');
        var listefilms = item.films;

        listefilms.forEach(function(element) {
          jQuery.ajax({
              method: "GET",
              url: element
            })
            .done(function(film) {
              var apapritions = jQuery('<li class="films">' + film.title + '</li>');
              films.append(apapritions);
            });
        });
        div1.append(titre);
        div1.append(date);
        div1.append(poids);
        div1.append(films);

          jQuery('#idarea').append(div1);
        //  console.log($('#idarea').text());
      });
    });
}

function nomPersonnage(pageperso) {
  jQuery('#idarea').html("");
  $.ajax({
    method: "GET",
      url: "https://swapi.co/api/people/?page=" + pageperso + "",
      success: function(data) {
      liste = data['results'];
      var div1 = jQuery('<ul class="listeperso">');
      var listeperso = [];
      for (var element of liste) {
        listeperso.push(element.name);
      }
      var page = jQuery('<ul style="color:RGB(150,170,255)"> <a href="#"> Page </a> ' + pageperso + '</ul>');
      listeperso.forEach(function(item) {
        var titre = jQuery('<li>' + item + '</li>');
        page.append(titre);
        div1.append(page);
          jQuery('#perso').append(div1);
      });
    }
  });
  
}

function listerPersonnage() {
   jQuery('#idarea').html("");
  var pageperso = 1;
  for (pageperso = 1; pageperso < 8; pageperso++) {
    nomPersonnage(pageperso);
}}

function persosuivant() {
    idpersonnage = idpersonnage + 1;
  chercherPersonnage(idpersonnage);
}

function persoprecedent() {
  idpersonnage = idpersonnage - 1;
  chercherPersonnage(idpersonnage);
}


function SauvegarderPersonnage() {
    alert("Vous devez auparavant charger les détails des personnages");
   
    liste.forEach(function (item) {
        var div1 = jQuery('<div id="perso" class="col-sm-6 col-md-4 perso" >');
        var listefilms = item.films;
        var listetitres = [];
        listefilms.forEach(function (element) {
            jQuery.ajax({
                method: "GET",
                url: element
            })
                .done(function (film) {
                    listetitres.push(film.title);
                    div1.attr("data-films", listetitres);
                });
        });
        div1.attr("data-name", item.name);
        div1.attr("data-date", item.birth_year);
        div1.attr("data-mass", item.mass);
        console.log($(div1));

        let personnage = {
            Name: div1.attr('data-name'),
            BirdthDate: div1.attr('data-date'),
            Mass: div1.attr('data-mass'),
            Episodes: div1.attr('data-films')
        };

        $.ajax({
            type: 'POST',
            url: '/api/Persoes/',
            data: personnage,
            success: function () {
                alert("La modification a bien été effectuée");
                
                // RemplirDivCategorie(divCategorie, { ID: idCategorie, Nom: nomCategorie });
            },
            error: alert("La modification a bien été effectuée")
        });

    });
    

}
    

   
  
    //let perso = {
    //    Name : $('#Nom').val(),
    //    Prenom: $('#Prenom').val(),
    //    DateNaissance: $('#DateNaissance').val(),
    //    Email: $('#Email').val(),
    //    Telephone: $('#NumTel').val(),
    //    Adresse: $('#Adresse').val()
    //};
