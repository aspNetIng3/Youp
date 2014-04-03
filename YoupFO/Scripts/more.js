function setImage(img, img_title) {
    $(img).attr('src', '../Images/' + img_title + '.png');
}
function showOrHide(element) {
    if ($(element).is(':hidden')) {
        $(element).show('slow');
    }
    else {
        $(element).slideUp('slow');
    }
}