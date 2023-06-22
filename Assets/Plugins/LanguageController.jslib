mergeInto(LibraryManager.library, {

  SetToLeaderboard: function(value) {
    ysdk.getLeaderboards()
      .then(lb => {
        lb.setLeaderboardScore("Money", value);
      });
  },
  
  GetLang : function(){
      var lang = ysdk.environment.i18n.lang;
      var bufferSize = lengthBytesUTF8(lang) + 1;
      var buffer = _malloc(bufferSize);
      stringToUTF8(lang, buffer, bufferSize);
      return buffer;
    },
    
    

});
