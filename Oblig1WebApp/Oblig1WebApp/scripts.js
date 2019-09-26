// For en vei - og returdatoer(vise / skjule), samt vise / skjule "Returdato" nederst på skjermen
$(document).ready(function () {
    $("#retur").hide();
    $("#visReturDato").hide();
    $("#turRetur").click(function () {
         $("#retur").show();
         $("#visReturDato").show();
    });

    $("#enVei").click(function () {
        $("#retur").hide();
        $("#visReturDato").hide();
    });
});

$(document).ready(function () {
    $('[data-toggle="popover"]').popover({ html: true });
});

// Ajax for første avgang - dynamisk henting av data
$(function () {
    // Kaller på hentAlleAvganger og bygger opp dropdown-liste når siden lastes
    $.ajax({
        url: '/Avgang/hentAlleAvganger',
        type: 'GET',
        dataType: 'json',
        success: function (jsAvgang) {
            VisDropDownForste(jsAvgang);
        },
        error: function (x, y, z) {
        alert(x + '\n' + y + '\n' + z);
        }
    });

    // Oppretter en hendelse på dropdown-listen når siden lastes
    $("#dropForste").change(function () {
        var id = $(this).val();
        $.ajax({
            url: '/Avgang/hentAvgangInfo/' + id,
            type: 'GET',
            dataType: 'json',
            success: function (Avgang) {
                VisInfoForste(Avgang);
            },
            error: function (x, y, z) {
                alert(x + '\n' + y + '\n' + z);
            }
        });
    });

    // Oppretter en hendelse som kjøres når registreringsknappen trykkes
    $("#registrer").click(function () {
        // Bygger et js objekt fra dropdown feltene "Reise fra" og "Reise til"
        var jsInnForste = {
            forsteAvgang: $('#fraLokasjon :selected').text()
        }

        $.ajax({
            url: '/Avgang/registrerAvgang',
            type: 'POST',
            data: JSON.stringify(jsInnForste),
            contentType: "application/json;charset=utf-8",
            success: function (ok) {
                // Legg inn feilhåndtering dersom feil i registrering
                window.location.reload();
                // Reloader vinduet etter at kallet har returnert
            },
                error: function (x, y, z) {
                alert(x + '\n' + y + '\n' + z);
            }
        });
    })
})

// Setter forsteAvgang inn i select
function VisDropDownForste(jsAvgang) {
    var utStreng = "";
    for (var i in jsAvgang) {
        utStreng += "<option value='" + jsAvgang[i].id + "'>" + jsAvgang[i].forsteAvgang + "</option>";
    }
    $("#dropForste").append(utStreng);
}

// Viser forste avgang
function VisInfoForste(Avgang) {
    var utStreng = Avgang.forsteAvgang;
    $("#visInfoForste").html(utStreng);
}
       

// Ajax for siste avgang - dynamisk henting av data
$(function () {

    // Kaller på hentAlleAvganger og bygger opp dropdown-liste når siden lastes
    $.ajax({
        url: '/Avgang/hentAlleAvganger',
        type: 'GET',
        dataType: 'json',
        success: function (jsAvgang) {
            VisDropDownSiste(jsAvgang);
        },
            error: function (x, y, z) {
            alert(x + '\n' + y + '\n' + z);
        }
    });

    // Oppretter en hendelse på dropdown-listen når siden lastes
    $("#dropSiste").change(function () {
        var id = $(this).val();
        $.ajax({
            url: '/Avgang/hentAvgangInfo/' + id,
            type: 'GET',
            dataType: 'json',
            success: function (Avgang) {
            VisInfoSiste(Avgang);
        },
            error: function (x, y, z) {
            alert(x + '\n' + y + '\n' + z);
        }
        });
    });

    // Oppretter en hendelse som kjøres når registreringsknappen trykkes
    $("#registrer").click(function () {
        // Bygger et js objekt fra dropdown feltene "Reise fra" og "Reise til"
        var jsInnSiste = {
            sisteAvgang: $('#tilLokasjon :selected').text()
        }

        $.ajax({
            url: '/Avgang/registrerAvgang',
            type: 'POST',
            data: JSON.stringify(jsInnSiste),
            contentType: "application/json;charset=utf-8",
            success: function (ok) {
                // Legg inn feilhåndtering dersom feil i registrering
                window.location.reload();
                // Reloader vinduet etter at kallet har returnert
            },
                error: function (x, y, z) {
                alert(x + '\n' + y + '\n' + z);
            }
        });
    })
})

// Setter sisteAvgang inn i select
function VisDropDownSiste(jsAvgang) {
    var utStreng = "";
    for (var i in jsAvgang) {
            utStreng += "<option value='" + jsAvgang[i].id + "'>" + jsAvgang[i].sisteAvgang + "</option>";
        }
    $("#dropSiste").append(utStreng);
}
    
// Viser siste avgang
function VisInfoSiste(Avgang) {
    var utStreng = Avgang.sisteAvgang;
    $("#visInfoSiste").html(utStreng);
}
        
// Script for å vise / skjule spesielleBehov ved klikk
$("#visCheckboxer").hide();
var x = document.getElementById('visCheckboxer');
 $('#visSpesielleBehov').on('click', function () {
     if (window.getComputedStyle(x).visibility == "hidden") {
         $("#visCheckboxer").show();
     x.style.visibility = "visible";
     } else {
         $("#visCheckboxer").hide();
     x.style.visibility = "hidden";
 }
 });

// Script for å skrive ut utreise - og returdato
// Utreise
document.getElementById("datoUtreise").addEventListener("change", function () {
    var input = this.value;
    utStrengDatoUtreise = " " + input;
    $("#utreiseDatoUt").text(utStrengDatoUtreise);
});
    
// Retur
document.getElementById("datoRetur").addEventListener("change", function () {
    var input = this.value;
    utStrengDatoUtreise = " " + input;
    $("#returDatoUt").text(utStrengDatoUtreise);
});

// Script for å skrive ut antall reisende av hver type reisende
$(':input').on('keyup mouseup', function () {
    // Voksen
    var utStrengVoksen = "";
    utStrengVoksen += " " + $('#voksen').val();
    if ($('#voksen').val() == 1) {
        utStrengVoksen += " voksen";
    } else if ($('#voksen').val() > 1) {
        utStrengVoksen += " voksene";
    } else {
        utStrengVoksen = "";
    }
    $("#numberVoksen").text(utStrengVoksen);
        
    // Barn (0-5)
    var utStrengSmåbarn = "";
    utStrengSmåbarn += " " + $('#barn0_5').val();
    if ($('#barn0_5').val() >= 1) {
        utStrengSmåbarn += " barn (0-5 år)";
    } else {
        utStrengSmåbarn = "";
    }
    $("#numberSmåbarn").text(utStrengSmåbarn);
        
    // Student
    var utStrengStudent = "";
    utStrengStudent += " " + $('#student').val();
    if ($('#student').val() == 1) {
        utStrengStudent += " student";
    } else if ($('#student').val() > 1) {
        utStrengStudent += " studenter";
    } else {
        utStrengStudent = "";
    }
    $("#numberStudent").text(utStrengStudent);
        
    // Honnør
    var utStrengHonnoer = "";
    utStrengHonnoer += " " + $('#honnoer').val();
    if ($('#honnoer').val() == 1) {
        utStrengHonnoer += " honnør";
    } else if ($('#honnoer').val() > 1) {
        utStrengHonnoer += " honnører";
    } else {
        utStrengHonnoer = "";
    }
    $("#numberHonnoer").text(utStrengHonnoer);
        
    // Vernepliktig
    var utStrengVernepliktig = "";
    utStrengVernepliktig += " " + $('#vernepliktig').val();
    if ($('#vernepliktig').val() == 1) {
        utStrengVernepliktig += " vernepliktig";
    } else if ($('#vernepliktig').val() > 1) {
    utStrengVernepliktig += " vernepliktige";
    } else {
        utStrengVernepliktig = "";
    }
    $("#numberVernepliktig").text(utStrengVernepliktig);

    // Barn (6-17 år)
    var utStrengBarn = "";
    utStrengBarn += " " + $('#barn6_17').val();
    if ($('#barn6_17').val() >= 1) {
        utStrengBarn += " barn (6-17 år)";
    } else {
        utStrengBarn = "";
    }
    $("#numberBarn").text(utStrengBarn);
        
        
    // Totalt antall reisende (ikke ferdig)
    var array = [$('#voksen'), $('#barn0_5'), $('#student'), $('#honnoer'), $('#vernepliktig'), $('#barn6_17')];
    var utStrengTotaltReisende = 0;
    for (var i in array) {
        if (array[i].val() >= 1) {
            utStrengTotaltReisende += array[i].val();
        }
    }
    $("#numberTotaltReisende").text(utStrengTotaltReisende); 
}).trigger('mouseup');

// Script for å vise valgte checkboxer
$('input[type=checkbox]').on('click', function () {
    // Barnevogn
    if ($('input[name="barnevogn"]').is(':checked')) {
        var utStrengBarnevogn = "";
        utStrengBarnevogn += " " + $('#barnevogn').val();
        $("#CheckboxBarnevogn").html(utStrengBarnevogn);
    } else {
        utStrengBarnevogn = " ";
        $("#CheckboxBarnevogn").html(utStrengBarnevogn);
    }
        
    // Sykkel
    if ($('input[name="sykkel"]').is(':checked')) {
        var utStrengSykkel = "";
        utStrengSykkel += " " + $('#sykkel').val();
        $("#CheckboxSykkel").html(utStrengSykkel);
    } else {
        utStrengSykkel = " ";
        $("#CheckboxSykkel").html(utStrengSykkel);
    }

    // Hund over 40 cm
    if ($('input[name="hundover_40cm"]').is(':checked')) {
        var utStrengHund = "";
        utStrengHund += " " + $('#hundover_40cm').val();
        $("#Checkboxhund").html(utStrengHund);
    } else {
        utStrengHund = " ";
        $("#Checkboxhund").html(utStrengHund);
    }

    // Kjæledyr under 40 cm
    if ($('input[name="kjaeledyrunder_40cm"]').is(':checked')) {
        var utStrengDyr = "";
        utStrengDyr += " " + $('#kjaeledyrunder_40cm').val();
        $("#Checkboxdyr").html(utStrengDyr);
    } else {
        utStrengDyr = " ";
        $("#Checkboxdyr").html(utStrengDyr);
    }
});


// Unchecker alle checkboxene dersom man klikker på "ingen spesielle behov" og fjerner dynamisk output nederst
$('#ingenSpesialBehov').on('click', function () {
    $(".uncheck").click(function () {
        $('input[name="barnevogn"').prop("checked", false);
        $('input[name="sykkel"').prop("checked", false);
        $('input[name="hundover_40cm"').prop("checked", false);
        $('input[name="kjaeledyrunder_40cm"').prop("checked", false);

        utStrengBarnevogn = "";
        $("#CheckboxBarnevogn").html(utStrengBarnevogn);
        utStrengSykkel = " ";
        $("#CheckboxSykkel").html(utStrengSykkel);
        utStrengHund = " ";
        $("#Checkboxhund").html(utStrengHund);
        utStrengDyr = " ";
        $("#Checkboxdyr").html(utStrengDyr);
    });
}); 