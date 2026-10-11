package services;

import daos.BookDAO;
import models.BookEntity;


import java.util.List;

public class BookService {
    private static BookDAO dao = new BookDAO();

    public static List<BookEntity> getAllBooks(){
        return dao.findAll();
    }
    public static List<BookEntity> getOrderByPublishDesc(){
        return dao.findOrderByPublishDateDesc();
    }
    public static BookEntity getByBookName(String bookName){
        return dao.findBy("BookName",bookName);
    }
    public static boolean deleteBook(String id){
        if(!dao.exists(id)){
            return false;
        }
        return dao.delete(id);
    }
    public static boolean updateBook(String id,String key,String value){
        if(!dao.exists(id)){
            return false;
        }
        return dao.update(id,key,value);
    }
    public static boolean addBook(BookEntity book){
        return dao.insert(book);
    }
    public static boolean existBook(String id){
        return dao.exists(id);
    }

}
