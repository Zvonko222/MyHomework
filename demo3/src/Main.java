import apps.LibraryApplication;
import bases.BaseApplication;

public class Main {
    public static void main(String[] args) {

        BaseApplication app = new LibraryApplication();
//
        app.onCreate();
        app.run();
        app.onDestroy();
    }



}