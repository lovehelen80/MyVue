<template>
  <div>
    <div id="TopTitle">
      <mt-header v-bind:title="msg">
      </mt-header>
      <mt-field label="￥" placeholder="在此输入记账金额" type="number" v-model="money"></mt-field>
    </div>
    <div id="BillTypes" >
      <div v-for="item in billType" :key="item.id" class="item" v-on:click="Add(item.id)">
        <div class="item_img">
          <i class="fa fa-3x" v-bind:class="item.fontStyle"></i>
        </div>
        <span>{{item.name}}</span>
      </div>

      <div style="clear: both"></div>

    </div>
  </div>
</template>

<script>
  import { Toast } from 'mint-ui'; // 引入mint-ui弹窗，对于js要调用的还需要这样引用一下。不知道为什么
  export default {
    name: 'hello',
    data() {
      return {
        msg: '理财从记账开始',
        billType: [], // 账单数据
        money: '',   // 记账的金额
      }
    },
    created() {
      this.$http.get('/bill/GetBillType').then(response => {
        this.billType = response.body.result.data;
      }, response => {
        Toast("获取数据出错")
      });
    },
    methods: {
      Add(m) {
        if (this.money == '') {
          Toast('请先输入记账金额，再选择资金去向');
          return;
        }
        ;
        this.$http.post('/bill/AddBills', {
          Money: this.money,
          BillTypeId: m,
        }).then(r => {
          if (r.body.result.result) {
            Toast({
              message: '记账成功',
              iconClass: 'icon icon-success'
            });
            this.money = '';
          } else {
            Toast(r.body.result.data);
          }
        }, r => {
          Toast("数据传输失败");
        })


      },
    }
  }
</script>

<!-- Add "scoped" attribute to limit CSS to this component only -->
<style scoped>
  #TopTitle{
    position: fixed;
    top: 0;
    width: 100%;
    background-color: #eee;
    z-index: 1;
  }
  #TopTitle div *{
    border-style: none;
  }
  #BillTypes{
    margin-top: 88px;
    position: relative;
    height: auto;
    background-color: #eee;
  }
  #BillTypes .item{
    height: 100px;
    padding: 11px 15px;
    vertical-align: top;
    border-right: 1px solid #fff;
    border-bottom: 1px solid #fff;
    position: relative;
    float: left;
    width: 33.33333%;
    box-sizing: border-box;
  }
  #BillTypes .item .item_img{
    clear: both;
    padding-bottom: 8px;
  }
</style>
