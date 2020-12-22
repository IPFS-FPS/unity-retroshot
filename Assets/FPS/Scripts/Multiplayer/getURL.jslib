mergeInto(LibraryManager.library, {
  GetRoomFromURL: function () {
    var url = window.top.location.href;
    var room = url.split("?")[1];
    return !room ? 0 : room;
  },
});