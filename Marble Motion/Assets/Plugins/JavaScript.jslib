mergeInto(LibraryManager.library, {

  ShowAlert: function (str) {
    window.alert(Pointer_stringify(str));
  },

  GetCookies: function () {
    var returnStr = document.cookie;
    var bufferSize = lengthBytesUTF8(returnStr) + 1;
    var buffer = _malloc(bufferSize);
    stringToUTF8(returnStr, buffer, bufferSize);
    return buffer;
  },
});