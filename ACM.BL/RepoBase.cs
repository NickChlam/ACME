namespace ACM.BL
{
    public abstract class RepoBase
    {
        
        public virtual bool Save<T>(T entity) where T : class
        {
            var success = true;
            
         
            return success;
        }
    }
}