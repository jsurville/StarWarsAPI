function chercherPlanete(idplanete) {
  jQuery('#idarea').html("");

  jQuery.ajax({
      method: "GET",
      url: "https://swapi.co/api/planets/?page=" + idplanete + ""
    })
    .done(function(data) {
      liste = data["results"];
      liste.forEach(function(item) {
        var div1 = jQuery('<div class="col-sm-6 col-md-4 planete" >');
        var titre = jQuery('<h2 id="h2plan"">' + item.name + '</h2>');
        var climat = jQuery('<ul> Climat : ' + item.climate + '</ul>');
        var terrain = jQuery('<ul> Terrain : ' + item.terrain + '</ul>');
        var films = jQuery('<ul class="films" > Episodes : </br> </ul>');
        var listefilms = item.films;

        listefilms.forEach(function(element) {
          jQuery.ajax({
              method: "GET",
              url: element
            })
            .done(function(film) {
              var apapritions = jQuery('<li class="films">' + film.title + '</li>');
              films.append(apapritions);
            })
        })
        div1.append(titre);
        div1.append(climat);
        div1.append(terrain);
        div1.append(films);
        jQuery('#idarea').append(div1);
      });
    });
}

function nomPlanete(pageplanete) {
  jQuery('#idarea').html("");

  jQuery.ajax({
      method: "GET",
      url: "https://swapi.co/api/planets/?page=" + pageplanete + ""
    })
    .done(function(data) {
      liste = data["results"];
      var div1 = jQuery('<ul class="listeplanete">');
      var listeplanete = [];
      for (var element of liste) {
        listeplanete.push(element.name);
      }
      var page = jQuery('<ul style="color:RGB(150,170,255)"> <a href="#"> Page </a> ' + pageplanete + '</ul>');
      listeplanete.forEach(function(item) {
        var titre = jQuery('<li>' + item + '</li>');
        page.append(titre);
        div1.append(page);
        jQuery('#idarea').append(div1);
      });
    });
}

function listerPlanete() {
  jQuery('#idarea').html("");
  var pageplanete = 1;
  for (pageplanete = 1; pageplanete < 8; pageplanete++) {
    nomPlanete(pageplanete);
  }

}


function planetesuivant() {
  idplanete = idplanete + 1;
  chercherPlanete(idplanete);
}

function planeteprecedent() {
  idplanete = idplanete - 1;
  chercherPlanete(idplanete);
}