package daos;

import models.BookEntity;
import tools.DBHelper;

import java.sql.ResultSet;
import java.sql.SQLException;
import java.util.ArrayList;
import java.util.List;

public class BookDAO {
    public boolean exists(String id){
        String sql = """
                select * 
                from book
                where BookId = '%s'
                """;
        sql = sql.formatted(id);
        ResultSet rs = DBHelper.ExecuteQuery(sql);
        try{
            return rs.next();
        } catch (SQLException e) {
            e.printStackTrace();
            return false;
        }
    }
    public boolean insert(BookEntity book){
        String sql = """
                insert into book
                (BookName,Author,Category,Publisher,PublishDate,Price,Stock)
                values
                ('%s','%s','%s','%s','%s','%s','%s')
                """.formatted(book.getName(),book.getAuthor(),book.getCategory(),book.getPublisher(),book.getPublishDate(),book.getPrice(),book.getStock());
        return DBHelper.ExecuteUpdate(sql) > 0;
    }
    public boolean delete(String id){
        String sql = """
                delete from book
                where BookId = '%s'
                """.formatted(id);
        return DBHelper.ExecuteUpdate(sql) > 0;
    }
    public boolean update(String id,String key,String value){
        String sql = """
                update book 
                set %s = '%s' 
                where BookId = '%s'
                """.formatted(key,value,id);
        return DBHelper.ExecuteUpdate(sql)>0;
    }

    private BookEntity map(ResultSet rs) {
        BookEntity book = new BookEntity();
        try{
            book.setId(rs.getString("BookId"));
            book.setName(rs.getString("BookName"));
            book.setAuthor(rs.getString("Author"));
            book.setCategory(rs.getString("Category"));
            book.setPublisher(rs.getString("Publisher"));
            book.setPublishDate(rs.getString("PublishDate"));
            book.setPrice(rs.getString("Price"));
            book.setStock(rs.getString("Stock"));
        } catch (Exception e) {
            e.printStackTrace();
        }
        return book;
    }
    public List<BookEntity> findOrderByPublishDateDesc(){
        String sql = """
                select * 
                from book
                order by PublishDate desc
                """;
        ResultSet rs = DBHelper.ExecuteQuery(sql);
        List<BookEntity> books = new ArrayList<>();
        try{
            while(rs.next()){
                BookEntity book = map(rs);
                books.add(book);
            }
            return books;
        } catch (Exception e) {
            e.printStackTrace();
            return null;
        }
    }
    public List<BookEntity> findAll(){
        String sql = "select * from book";
        ResultSet rs = DBHelper.ExecuteQuery(sql);
        List<BookEntity> books = new ArrayList<>();
        try{
            while(rs.next()){
                books.add(map(rs));
            }
        } catch (Exception e) {
            e.printStackTrace();
        }
        return books;
    }
    public BookEntity findBy(String key, String value){
        String sql = """
                select *
                from book
                where %s = '%s'
                """.formatted(key,value);
        ResultSet rs = DBHelper.ExecuteQuery(sql);
        try{
            if(rs.next()){
                return map(rs);
            }
        }catch (SQLException e){
            e.printStackTrace();
        }
        return null;
    }
    public BookEntity findById(String id){
        String sql = """
                select * 
                from book 
                where BookId = '%s'
                """.formatted(id);
        ResultSet rs = DBHelper.ExecuteQuery(sql);
        try{
            if(rs.next()){
                return map(rs);
            }
        }catch(SQLException e){
            e.printStackTrace();
        }
        return null;
    }
}
