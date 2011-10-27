using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SharpFusion;

namespace ServerCydeData
{
    public partial class Proc_Select
    {
        public String[][] GetParameters()
        {
            List<String[]> parameters = new List<string[]>();
            this.get_children_proc_select_condition_proc_select_ids.ToList().ForEach(x =>
            {
                if (!x.comparison_operator.LikeOne(new string[] { "is null", "is not null" }))
                {
                    parameters.Add(new string[] { x.ParameterName1, x.constant_value });
                    if (x.comparison_operator.Like("between"))
                    {
                        parameters.Add(new string[] { x.ParameterName2, x.constant_value_2 });
                    }
                }
            });
            return parameters.ToArray();
        }

    }
}