package bases;

public  abstract class BaseApplication {
    public  void onCreate(){

    };
    public  void onDestroy(){

    };
    public abstract void run();
    public final void finish(){
        onDestroy();
        System.exit(0);
    }
}
