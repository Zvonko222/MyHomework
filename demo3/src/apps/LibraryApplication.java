package apps;

import bases.BaseApplication;

import models.BookEntity;
import services.BookService;

import tools.InputUtil;
import tools.Terminal;

import java.util.List;

import static tools.InputUtil.sc;


public class LibraryApplication extends BaseApplication {
    @Override
    public void onCreate() {
        super.onCreate();
        System.out.println("On Create!!!");
    }

    @Override
    public void onDestroy() {
        super.onDestroy();
        System.out.println("Application out");
    }

    @Override
    public void run() {
        mainLoop();
    }

    private void mainLoop() {
        while (true) {
            showMenu();
            String inputStr = sc.nextLine();
            // Input keyboard
            switch (inputStr) {
                case "1":
                    Terminal.clearScreen();
                    addBookInfo();
                    Terminal.operationExit();
                    break;
                case "2":
                    Terminal.clearScreen();
                    showBookInfo();
                    Terminal.operationExit();
                    break;
                case "3":
                    Terminal.clearScreen();
                    updateBookInfo();
                    Terminal.operationExit();
                    break;
                case "4":
                    Terminal.clearScreen();
                    deleteBookInfo();
                    Terminal.operationExit();
                    break;
                case "5":
                    Terminal.clearScreen();
                    findBookInfo();
                    Terminal.operationExit();
                    break;
                case "6":
                    Terminal.clearScreen();
                    sortBookInfo();
                    Terminal.operationExit();
                    break;
                case "7":
                    Terminal.clearScreen();
                    finish();
                    return;
                default:
                    Terminal.clearScreen();
                    System.out.println("ERROR,Re-Enter");
                    break;
            }
        }
    }

    private void printBooks(List<BookEntity> books) {
        for (BookEntity book : books) {
            printBook(book);
        }
    }

    private void printBook(BookEntity book) {
        System.out.println("-----------------------");
        System.out.println("Id : " + book.getId());
        System.out.println("Name : " + book.getName());
        System.out.println("Author : " + book.getAuthor());
        System.out.println("Category : " + book.getCategory());
        System.out.println("Publisher : " + book.getPublisher());
        System.out.println("Publish Date : " + book.getPublishDate());
        System.out.println("Price : " + book.getPrice());
        System.out.println("Stock : " + book.getStock());
    }

    private void sortBookInfo() {
        List<BookEntity> books = BookService.getOrderByPublishDesc();
        printBooks(books);
    }

    private void findBookInfo() {
        showBookInfo();
        System.out.println("\nPlease enter book name");

        String inputName = sc.nextLine();

        BookEntity book = BookService.getByBookName(inputName);

        if (book == null) {
            System.out.println("Book not found");
            return;
        }
        printBook(book);
    }

    private void deleteBookInfo() {
        showBookInfo();
        System.out.println("Please enter the id you want to delete");
        String id = InputUtil.enterIntDigital();

        if (BookService.deleteBook(id)) {
            System.out.println("Deletion successful");
        } else {
            System.out.println("Deletion failed");
        }
    }

    private void showUpdateMenu() {
        System.out.println("1.Name");
        System.out.println("2.Author");
        System.out.println("3.Categroy");
        System.out.println("4.Publisher");
        System.out.println("5.PublishDate");
        System.out.println("6.Price");
        System.out.println("7.Stock");
    }

    private void updateBook(String id, String key) {
        System.out.println("Select " + key);
        System.out.println("Please enter value");

        String value = sc.nextLine();

        if (BookService.updateBook(id, key, value)) {
            System.out.println("Update successful");
        } else {
            System.out.println("Update failed");
        }
    }
    private String getBookField(String option){
        return switch (option){
            case "1" -> "BookName";
            case "2" -> "Author";
            case "3" -> "Category";
            case "4" -> "Publisher";
            case "5" -> "PublishDate";
            case "6" -> "Price";
            case "7" -> "Stock";
            default -> null;
        };
    }
    private void updateBookInfo() {
        showBookInfo();
        System.out.println("\nPlease enter the ID you want to update");


        String id = InputUtil.enterIntDigital();

        if (BookService.existBook(id)) {
            // Exist
            System.out.println("please enter the information you wish to update\n");
            showUpdateMenu();
            while (true) {

                String input = sc.nextLine();
                String field = getBookField(input);
                if(field == null){
                    System.out.println("Does not have option,repeat please");
                    continue;
                }
                updateBook(id,field);
                return;
            }

        } else {
            // Does not exist
            Terminal.clearScreen();
            showBookInfo();
            System.out.println("Does not have book id");
        }


    }

    private void showBookInfo() {
        List<BookEntity> books = BookService.getAllBooks();
        if(books.isEmpty()){
            System.out.println("No books found");
            return;
        }
        printBooks(books);
    }


    private void addBookInfo() {
        // input book information
        BookEntity book = new BookEntity();

        System.out.println("Pleas enter book information ");
        System.out.println("Name : ");
        book.setName(sc.nextLine());
        System.out.println("Author :");
        book.setAuthor(sc.nextLine());
        System.out.println("Category :");
        book.setCategory(sc.nextLine());
        System.out.println("Publisher :");
        book.setPublisher(sc.nextLine());
        System.out.println("Publish Date: ");
        book.setPublishDate(InputUtil.enterDateFormat());
        System.out.println("Price : ");
        book.setPrice(InputUtil.enterDoubleDigital());
        System.out.println("Stock :");
        book.setStock(InputUtil.enterIntDigital());

        // insert book information
        if (BookService.addBook(book)) {
            System.out.println("Insert successful");
        } else {
            System.out.println("Insert failed");
        }
    }

    private void showMenu() {
        System.out.println("图书管理系统");
        System.out.println("   1.添加图书信息");
        System.out.println("   2.显示所有图书信息");
        System.out.println("   3.修改图书信息");
        System.out.println("   4.删除图书信息");
        System.out.println("   5.查找图书信息");
        System.out.println("   6.按照出版时间排序");
        System.out.println("   7.退出系统");
    }
}
