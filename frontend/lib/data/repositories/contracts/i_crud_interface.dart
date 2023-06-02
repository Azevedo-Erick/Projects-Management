abstract class ICrudInterface<T> {
  Future<List<T>> getAll();
  Future<T> getOne();
  Future<bool> create(T model);
  Future<bool> update(T model, int id);
  Future<bool> delete();
}
