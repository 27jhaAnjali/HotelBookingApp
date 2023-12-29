namespace HotelBookingAPI.Interfaces
{
    public interface IRepository<K,T> where T : class
    {
        public T Add(T entity);
        public T Delete(K key);
        public T Get(K key);
        public T Update(T entity);
        public IList<T> GetAll();
    }
}
