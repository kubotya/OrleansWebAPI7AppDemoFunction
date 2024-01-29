﻿using Microsoft.AspNetCore.Mvc;
using OrleansWebAPI7AppDemo.Models.Accounting;
using OrleansWebAPI7AppDemo.Orleans.Abstractions;

namespace OrleansWebAPI7AppDemo.Controllers.Accounting
{
    [ApiController]
    [Route("Accounting/[controller]")]
    public class CompanyController : ControllerBase
    {

        private readonly IGrainFactory _grains;

        public CompanyController(IGrainFactory grains)
        {
            _grains = grains;
        }

        /// <summary>
        /// 会社情報のコード一覧を取得します
        /// </summary>
        /// <returns></returns>
        [HttpGet()]
        [Route("")]
        public IList<string> Index()
        {
            var companies = new List<string>();
            // ↓↓　一般的にはデータベースから取得する
            // SELECT * FROM Company;
            companies.Add("t283162780");
            // ↑↑
            return companies;
        }
        /// <summary>
        /// 会社情報をコードを指定して取得します
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet()]
        [Route("{id}")]
        public async Task<IActionResult> Get(string id)
        {
            // グレインの呼び出し
            var sessionGrain = _grains.GetGrain<ICompanyGrain>(id);
            // 指定グレインのGETメソッドを実行して結果を取得する
            var session = await sessionGrain.Get();
            if (session == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(session);
            }
        }
        /// <summary>
        /// 会社情報を追加・修正します。
        /// </summary>
        /// <param name="id"></param>
        /// <param name="company"></param>
        /// <returns></returns>
        [HttpPut()]
        [Route("{id}")]
        public async Task<Company> Set(string id , [FromBody] Company company)
        {
       
            var campanyGrain = _grains.GetGrain<ICompanyGrain>(id);
            await campanyGrain.Set(company);

            return company;
        }
        /// <summary>
        /// 会社情報を削除します
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete()]
        [Route("{id}")]
        public async Task<IActionResult> Remove(string id)
        {
            // ↓↓　テストでデータの一部分を更新
            var campanyGrain = _grains.GetGrain<ICompanyGrain>(id);
            await campanyGrain.Remove();
            // ↑↑
            return Ok();
        }
    }
}
