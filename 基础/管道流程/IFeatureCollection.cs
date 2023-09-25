using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace 管道流程
{
    public interface IFeatureCollection:IDictionary<Type,object>
    {


    }

    public class FeatureCollection :Dictionary<Type,object>, IFeatureCollection
    { 
     
    
    }


   
}
