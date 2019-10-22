public class RQRequestProcess_Extension : PXGraphExtension<RQRequestProcess>
    {
        [PXFilterable(new System.Type[] { })]
        public RQRequestProcess.RQRequestProcessing Records;

        public IEnumerable records()
        {
            var currentFilter = Base.Filter.Current;
            var newList = Base.Records.Select();
            ArrayList result = new ArrayList();

            foreach (PXResult<RQRequestLineOwned> listItme in newList)
            {
                var row = listItme.GetItem<RQRequestLineOwned>();
                RQRequest rq = PXSelect<RQRequest, Where<RQRequest.orderNbr, Equal<Required<RQRequestLineOwned.orderNbr>>>>.Select(Base, row.OrderNbr);
                RQRequestExt rqExt = PXCache<RQRequest>.GetExtension<RQRequestExt>(rq);
                if (rqExt.UsrProcess == ListProcessPO.PO)
                {
                    result.Add(row);
                }
            }

            return result;
        }
    }
