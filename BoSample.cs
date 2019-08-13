			SessionMgr sessionMgr = new SessionMgr();
            EnterpriseSession enterpriseSession = null;            
            try
            {
                enterpriseSession = sessionMgr.Logon("GBLADHEDANI\\dsampat2", "Dhangowda1", "szrh41u12018.csfb.cs-group.com:6400", "secWinAD");

                using (InfoStore infoStore = (InfoStore)enterpriseSession.GetService("InfoStore"))
                {
                    string[] countries = new string[] {"India"};
                    foreach (var country in countries)
                    {
                        Console.WriteLine("---------" + country + "----------");
                        using (var reportEngine = Utilities.RetrieveReportEngine(enterpriseSession))
                        {
                            Console.WriteLine("got reportengine " + watch.ElapsedMilliseconds.ToString());
                            using (var drillerWebi = Utilities.SearchReports(infoStore, "Tenor").FirstOrDefault())
                            {
                                if (drillerWebi != null)
                                {
                                    IDocumentInstance doc = reportEngine.OpenDocument(drillerWebi.ID);
                                    {
                                        IPrompts prompts = doc.GetPrompts();
                                        DateTime currDate = new DateTime(2013, 6, 28, 12, 0, 0);                                        

                                        prompts[0].EnterValues(new string[] {currDate.ToString("M/dd/yyyy hh:mm:ss tt")});
                                        prompts[1].EnterValues(new string[] {country});
                                        
                                        doc.SetPrompts();

                                        doc.Refresh();
										
                                        IBinaryView xlsView = doc.GetView(OutputFormatType.Xls) as IBinaryView;

                                        var fileName = drillerWebi.Title + "_" + country + ".xls";
                                        if (xlsView != null)
                                        {
                                            using (var stream = xlsView.GetStream())
                                            {
                                                WriteBytes(stream, fileName);
                                                stream.Close();
                                            }
                                        }

                                        xlsView = null;
                                        prompts = null;


                                        doc.CloseDocument();
                                        doc.Dispose();                                        
                                    }
                                }
                            }
                            reportEngine.Close();
                        }                        
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex);
            }
            finally
            {
                if (enterpriseSession != null)
                {
                    enterpriseSession.Logoff();
                    enterpriseSession.Dispose();
                }
                sessionMgr.Dispose();
            }